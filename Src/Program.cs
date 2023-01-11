using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Text;
using System.Linq;

namespace lump_stich
{
    class Lump_Stich_Main
    {
        static void Main(string[] args)
        {
            double version = 1.05;
            Console.Title = ($"Lump Stich - V {version}");

            string[] file_args = new string[2];
            Bsp_Lmp_Parser ls_parser = new Bsp_Lmp_Parser(); 

            Console.WriteLine($"===Lump Stich===\n--Version: {version}--\n--Made by: Rim032--\n");

            Console.WriteLine("Drag and drop your .lmp file.");
            file_args[0] = format_file_location(Console.ReadLine());

            Console.WriteLine("Drag and drop your .bsp file.");
            file_args[1] = format_file_location(Console.ReadLine());

            if (file_args != null)
            {
                if (File.Exists(file_args[0]) && File.Exists(file_args[1]))
                {
                    if (correct_files_check(file_args[0]) == 2 && correct_files_check(file_args[1]) == 1)
                    {
                        if (is_valid_lmp(file_args[0]) && is_valid_bsp(file_args[1]))
                        {
                            ls_parser.gather_lump_info(file_args[0]);
                            ls_parser.insert_lump_info(file_args[1], file_args[0]);
                        }
                        else
                        {
                            Console.WriteLine("[ERROR]: .bsp or .lmp file is corrupted or deformed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("[ERROR]: Listed file(s) are not in a .bsp or .lmp format.");
                    }
                }
                else
                {
                    Console.WriteLine("[ERROR]: .lmp or .bsp file does not exist.");
                }
            }

            Console.WriteLine("\nLump Stich finished... Press any key to exit.");
            Console.ReadKey();
        }


        protected static bool is_valid_lmp(string lump_file)
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

        protected static bool is_valid_bsp(string bsp_file)
        {
            if (bsp_file != null)
            {
                Stream bsp_file_read = File.Open(bsp_file, FileMode.Open);

                using (BinaryReader bsp_file_br = new BinaryReader(bsp_file_read))
                {
                    Byte[] bsp_ident = bsp_file_br.ReadBytes(4);
                    if(Encoding.ASCII.GetString(bsp_ident) == "VBSP")
                    {
                        bsp_file_read.Dispose();
                        return true;
                    }
                }

                bsp_file_read.Dispose();
            }

            return false;
        }


        private static string format_file_location(string file)
        {
            string final_file = "";
            if (file != null)
            {
                string[] file_arr = file.Split("\"");

                for (int i = 0; i < file_arr.Length; i++)
                {
                    if (file_arr[i] != "\"")
                    {
                        final_file += file_arr[i];
                    }
                }
            }

            return final_file;
        }

        private static int correct_files_check(string file)
        {
            if(file != null)
            {
                string file_extn = Path.GetExtension(file);

                if(file_extn == ".bsp")
                {
                    return 1;
                }
                else if(file_extn == ".lmp")
                {
                    return 2;
                }
            }

            return 0;
        }
    }


    public class Bsp_Header
    {
        public string identity;
        public int versionA;
        public int file_offset;
        public int file_length;
        public int versionB;
        public Byte[] compressed_length;
        public int revision;
    }


    public class Bsp_Lmp_Parser
    {
        public static List<string> lump_data_list = new List<string>();
        public static int[] duplicate_hammer_ids = new int[4096];

        public static Bsp_Header bsp_h = new Bsp_Header();

        public static bool is_debug_enabled = false;
        public static bool bsp_has_lump_data = false;


        private static void compare_hammer_ids(string bsp_file, string lump_file)
        {
            List<string> hammer_id_listA = new List<string>();
            List<string> hammer_id_listB = new List<string>();

            string fileA = File.ReadAllText(bsp_file);
            string fileB = File.ReadAllText(lump_file);

            const string lump_regex_id_key = @"(hammerid).*?[\d]+";

            try
            {
                Regex lump_id_rgxA = new Regex(lump_regex_id_key, RegexOptions.Singleline);
                foreach (Match lump_id_matchA in lump_id_rgxA.Matches(fileA))
                {
                    hammer_id_listA.Add(lump_id_matchA.ToString());
                }

                Regex lump_id_rgxB = new Regex(lump_regex_id_key, RegexOptions.Singleline);
                foreach (Match lump_id_matchB in lump_id_rgxB.Matches(fileB))
                {
                    hammer_id_listB.Add(lump_id_matchB.ToString());
                }
            }
            catch(Exception error)
            {
                Console.WriteLine($"[ERROR] {error.Message}.");
                return;
            }


            string[] hammer_id_arrA = hammer_id_listA.ToArray();
            string[] hammer_id_arrB = hammer_id_listB.ToArray();

            for (int i = 0; i < hammer_id_arrA.Length; i++)
            {
                for (int k = 0; k < hammer_id_arrB.Length; k++)
                {
                    if (hammer_id_arrA[i].Contains(hammer_id_arrB[k]))
                    {
                        duplicate_hammer_ids[k] = k;

                        if (is_debug_enabled)
                        {
                            Console.WriteLine($"(Matching Hammer ID) \"{hammer_id_arrA[i]}\" : \"{hammer_id_arrB[k]}\"");
                        }
                    }

                    if (duplicate_hammer_ids[k] > 0)
                    {
                        bsp_has_lump_data = true;
                    }
                }
            }

            if (is_debug_enabled)
            {
                Console.WriteLine($"Has duplicate ents/has ents?: {bsp_has_lump_data}");
            }
        }

        public void insert_lump_info(string bsp_file, string lump_file)
        {
            compare_hammer_ids(bsp_file, lump_file);
            gather_bsp_header_info(bsp_file);

            Console.WriteLine("\nStarting insertion of lump information...");

            try
            {
                Byte[] bsp_file_bytes = File.ReadAllBytes(bsp_file);
                string[] lump_data_arr = lump_data_list.ToArray();

                Stream bsp_write_file = File.Open(bsp_file.Replace(".bsp", "_s.bsp"), FileMode.Create);

                using (BinaryWriter lump_binary_writer = new BinaryWriter(bsp_write_file))
                {
                    if (bsp_file_bytes != null && lump_data_arr != null)
                    {
                        for (long j = 0; j < bsp_file_bytes.Length; j++)
                        {
                            if (j == bsp_h.file_offset)
                            {
                                lump_binary_writer.Write(Encoding.ASCII.GetBytes(lump_data_arr[0]));
                                lump_binary_writer.Write(Encoding.ASCII.GetBytes("\n"));

                                for (int k = 1; k < lump_data_arr.Length; k++)
                                {
                                    if (!bsp_has_lump_data && k != duplicate_hammer_ids[k])
                                    {
                                        lump_binary_writer.Write(Encoding.ASCII.GetBytes(lump_data_arr[k]));
                                    }
                                    else if (bsp_has_lump_data)
                                    {
                                        lump_binary_writer.Write(Encoding.ASCII.GetBytes(lump_data_arr[k]));
                                    }

                                    lump_binary_writer.Write(Encoding.ASCII.GetBytes("\n"));
                                }
                            }
                            else
                            {
                                if (j <= bsp_h.file_offset || j > (bsp_h.file_offset + bsp_h.file_length) - 2)
                                {
                                    lump_binary_writer.Write(bsp_file_bytes[j]);
                                }
                            }

                            if (is_debug_enabled)
                            {
                                if (j % (bsp_file_bytes.Length / 25) == 0)
                                {
                                    Console.WriteLine($"Inserting lump information... [{j}]");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"[ERROR] BSP file or lump entity data is null/unreadable.");
                    }

                    Console.WriteLine($"[SUCCESS]: Lump information succesfully inserted at \"{bsp_file.Replace(".bsp", "_s.bsp")}.\"");
                }
            }
            catch(Exception error)
            {
                Console.WriteLine($"[ERROR] {error.Message}.");
                return;
            }
        }

        protected internal static void gather_bsp_header_info(string bsp_file)
        {
            Console.WriteLine("\nStarting gathering of BSP header information...");

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


                if (is_debug_enabled)
                {
                    Console.WriteLine("\n--------------------");
                    Console.WriteLine($"Version: {bsp_h.versionA}");
                    Console.WriteLine($"File Offset: {bsp_h.file_offset}");
                    Console.WriteLine($"File Length: {bsp_h.file_length}");
                    Console.WriteLine($"Version 2: {bsp_h.versionB}");
                    Console.WriteLine($"Uncompressed Length: {BitConverter.ToString(bsp_h.compressed_length)}");
                    Console.WriteLine($"Revision: {bsp_h.revision}");
                    Console.WriteLine("--------------------\n");
                }
            }
            bsp_read_file.Dispose();

            Console.WriteLine($"[SUCCESS]: BSP header information succesfully gathered.");
            if (bsp_h.file_offset == 0)
            {
                Console.WriteLine("[ERROR]: BSP file offset for lump insertion is null/unreadable.");
            }
            else if (bsp_h.file_length == 0)
            {
                Console.WriteLine("[ERROR]: BSP file length for lump insertion is null/unreadable.");
            }

            if (bsp_h.versionA < 19 || bsp_h.versionA > 20)
            {
                Console.WriteLine("[WARNING]: BSP version is higher or lower than intended BSP file version (20).");
            }
            else if(bsp_h.versionA == 0)
            {
                Console.WriteLine("[WARNING]: BSP version is null/unreadable.");
            }
        }

        public void gather_lump_info(string lump_file)
        {
            Console.WriteLine("\nStarting gathering of lump information...");

            int match_index = 0;
            const string lump_regex_key = @"{[^}]+}"; //Regex key is taken from i-am-scott (https://github.com/i-am-scott)

            try
            {
                string file = File.ReadAllText(lump_file);

                Regex lump_chunk_rgx = new Regex(lump_regex_key, RegexOptions.Singleline);
                foreach (Match lump_match in lump_chunk_rgx.Matches(file))
                {
                    lump_data_list.Add(lump_match.ToString());

                    if (is_debug_enabled)
                    {
                        match_index++;
                        if (match_index % 1 == 0)
                        {
                            Console.WriteLine($"Gathering lump information... [{match_index}]");
                            Console.WriteLine(lump_match.ToString());
                        }
                    }
                }

                if (lump_chunk_rgx != null)
                {
                    Console.WriteLine($"[SUCCESS]: Lump information succesfully gathered.");
                }
                else
                {
                    Console.WriteLine($"[ERROR]: Lump information gathering process failed.");
                }
            }
            catch(Exception error)
            {
                Console.WriteLine($"[ERROR] {error.Message}.");
                return;
            }
        }
    }
}
