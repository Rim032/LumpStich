using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace LumpStich
{
    public partial class form_main : Form
    {
        private int error_count = 0;
        private int warning_count = 0;

        private string bsp_file = null;
        private string lmp_file = null;



        public void log_error(string error_msg)
        {
            if(error_msg == null)
            {
                return;
            }
            form_exec_log_listbox.Items.Add($"[ERROR]:   {error_msg}");

            error_count++;
            form_error_log_counter.Text = error_count.ToString();
        }

        public void log_warning(string warning_msg)
        {
            if (warning_msg == null)
            {
                return;
            }
            form_exec_log_listbox.Items.Add($"[WARNING]:   {warning_msg}");

            warning_count++;
            form_warning_log_counter.Text = warning_count.ToString();
        }

        public void log_success(string success_msg)
        {
            if (success_msg == null)
            {
                return;
            }
            form_exec_log_listbox.Items.Add($"[SUCCESS]:   {success_msg}");
        }



        public form_main()
        {
            InitializeComponent();
        }

        private static bool is_valid_lmp(string lump_file)
        {
            if (lump_file != null)
            {
                string[] lump_file_lines = File.ReadAllLines(lump_file);
                for (int i = 0; i < lump_file_lines.Length; i++)
                {
                    if (lump_file_lines.Contains("\"hammerid\" \"1\""))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool is_valid_bsp(string bsp_file)
        {
            if (bsp_file != null)
            {
                Stream bsp_file_read = File.Open(bsp_file, FileMode.Open);
                using (BinaryReader bsp_file_br = new BinaryReader(bsp_file_read))
                {
                    Byte[] bsp_ident = bsp_file_br.ReadBytes(4);
                    if (Encoding.ASCII.GetString(bsp_ident) == "VBSP")
                    {
                        bsp_file_read.Dispose();
                        return true;
                    }
                }

                bsp_file_read.Dispose();
            }

            return false;
        }



        private void form_bsp_file_btn_Click(object sender, EventArgs e)
        {
            bsp_file_dlg.Filter = "BSP files (*.bsp)|*.bsp";
            if (bsp_file_dlg.ShowDialog() != DialogResult.OK || !File.Exists(bsp_file_dlg.FileName))
            {
                log_error(".bsp file doesn't exist or is invalid.");
                return;
            }
            else if(!is_valid_bsp(bsp_file_dlg.FileName))
            {
                log_error(".bsp file is deformed.");
                return;
            }

            form_bsp_file_txtbox.Text = bsp_file_dlg.FileName;
            bsp_file = bsp_file_dlg.FileName;
        }

        private void form_lmp_file_btn_Click(object sender, EventArgs e)
        {
            lmp_file_dlg.Filter = "LMP files (*.lmp)|*.lmp";
            if (lmp_file_dlg.ShowDialog() != DialogResult.OK || !File.Exists(lmp_file_dlg.FileName))
            {
                log_error(".lmp file doesn't exist or is invalid.");
                return;
            }
            else if (!is_valid_lmp(lmp_file_dlg.FileName))
            {
                log_warning(".lmp file is possibly deformed? Missing worldspawn entity.");
            }

            form_lmp_file_txtbox.Text = lmp_file_dlg.FileName;
            lmp_file = lmp_file_dlg.FileName;
        }

        private void form_credit_tab_btn_Click(object sender, EventArgs e)
        {
            form2_main_window credit_form = new form2_main_window();
            credit_form.Show();
            credit_form.Location = new Point(form_main.MousePosition.X, form_main.MousePosition.Y);
        }



        private void form_start_stich_btn_Click(object sender, EventArgs e)
        {
            if(lmp_file == null || bsp_file == null)
            {
                log_error("Trying to execute without a valid .bsp or .lmp file?");
                return;
            }

            Bsp_Lmp_Parser ls_parser = new Bsp_Lmp_Parser();
            Bsp_Header bsp_h = new Bsp_Header();
            Stopwatch ls_timer = new Stopwatch();
            ls_timer.Start();


            if (ls_parser.gather_lump_data(lmp_file)) { log_success("Lump information gathered."); }
            else { log_error("Failed to gather lump information."); }

            if (ls_parser.compare_hammer_ids(bsp_file, lmp_file)) { log_success("Entity IDs were compared."); }
            else { log_error("Failed to compare entity IDs."); }

            if(gather_bsp_header_info(bsp_file, bsp_h)) { log_success("BSP header information gathered."); }
            else { log_success("Failed to gather BSP header information."); }

            if (check_bsp_header(bsp_h)) { log_success("BSP header information checked."); }
            else { log_error("Failed to check BSP header information."); }

            if (ls_parser.insert_lump_data(bsp_file, bsp_h)) { log_success("Lump data was inserted."); }
            else { log_error("Failed to insert lump data."); }
            

            ls_timer.Stop();
            float ls_timer_et = ls_timer.ElapsedMilliseconds;
            log_success($"Stiching completed in {ls_timer_et / 1000}s.");

            form_exec_log_listbox.Items.Add("");
            form_bsph_log_listbox.Items.Add("");
        }

        public bool gather_bsp_header_info(string bsp_file, Bsp_Header bsp_h)
        {
            if(bsp_file == null || bsp_h == null)
            {
                log_error("BSP file/BSP header is null/unreadable");
                return false;
            }
            try
            {
                Stream bsp_read_file = File.Open(bsp_file, FileMode.Open);
                using (BinaryReader bsp_binary_reader = new BinaryReader(bsp_read_file))
                {
                    bsp_h.identity = Encoding.ASCII.GetString(bsp_binary_reader.ReadBytes(4));
                    bsp_h.versionA = bsp_binary_reader.ReadInt32();

                    bsp_h.file_offset = bsp_binary_reader.ReadInt32();
                    bsp_h.file_length = bsp_binary_reader.ReadInt32();

                    bsp_h.versionB = bsp_binary_reader.ReadInt32();
                    bsp_h.compressed_length = bsp_binary_reader.ReadBytes(4);
                    bsp_h.revision = bsp_binary_reader.ReadInt32();

                    form_bsph_log_listbox.Items.Add($"Identity: {bsp_h.identity}");
                    form_bsph_log_listbox.Items.Add($"Version: {bsp_h.versionA}");
                    form_bsph_log_listbox.Items.Add($"Offset: {bsp_h.file_offset}");
                    form_bsph_log_listbox.Items.Add($"Length: {bsp_h.file_length}");
                    form_bsph_log_listbox.Items.Add($"Version 2: {bsp_h.versionB}");
                    form_bsph_log_listbox.Items.Add($"Revision: {bsp_h.revision}");
                }
                bsp_read_file.Dispose();
            }
            catch (Exception error)
            {
                log_error(error.Message);
                return false;
            }

            return true;
        }

        public bool check_bsp_header(Bsp_Header bsp_h)
        {
            if(bsp_h == null)
            {
                log_error("BSP header is null/unreadable.");
                return false;
            }


            if (bsp_h.file_offset == 0)
            {
                log_error("BSP file offset for lump insertion is null/unreadable.");
                return false;
            }

            if (bsp_h.file_length == 0)
            {
                log_error("BSP file length for lump insertion is null/unreadable.");
                return false;
            }

            if (bsp_h.versionA < 19 || bsp_h.versionA > 20)
            {
                log_warning("BSP version is higher or lower than intended BSP file version (20).");
            }
            else if (bsp_h.versionA == 0)
            {
                log_warning("BSP version is null/unreadable.");
            }

            return true;
        }
    }
}
