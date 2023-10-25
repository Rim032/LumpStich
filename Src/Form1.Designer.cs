namespace LumpStich
{
    partial class form_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_main));
            this.form_bsp_file_btn = new System.Windows.Forms.Button();
            this.form_bsp_file_txtbox = new System.Windows.Forms.TextBox();
            this.bsp_file_dlg = new System.Windows.Forms.OpenFileDialog();
            this.form_bsp_file_label = new System.Windows.Forms.Label();
            this.form_lmp_file_btn = new System.Windows.Forms.Button();
            this.form_lmp_file_txtbox = new System.Windows.Forms.TextBox();
            this.form_lmp_file_label = new System.Windows.Forms.Label();
            this.lmp_file_dlg = new System.Windows.Forms.OpenFileDialog();
            this.form_start_stich_btn = new System.Windows.Forms.Button();
            this.form_warning_log_txtbox = new System.Windows.Forms.Label();
            this.form_error_log_txtbox = new System.Windows.Forms.Label();
            this.form_error_log_counter = new System.Windows.Forms.Label();
            this.form_warning_log_counter = new System.Windows.Forms.Label();
            this.form_exec_log_listbox = new System.Windows.Forms.ListBox();
            this.form_credit_tab_btn = new System.Windows.Forms.Button();
            this.form_bsph_log_listbox = new System.Windows.Forms.ListBox();
            this.form_exec_log_label = new System.Windows.Forms.Label();
            this.form_bsph_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // form_bsp_file_btn
            // 
            this.form_bsp_file_btn.AutoSize = true;
            this.form_bsp_file_btn.Location = new System.Drawing.Point(12, 28);
            this.form_bsp_file_btn.Name = "form_bsp_file_btn";
            this.form_bsp_file_btn.Size = new System.Drawing.Size(75, 23);
            this.form_bsp_file_btn.TabIndex = 0;
            this.form_bsp_file_btn.Text = "Browse";
            this.form_bsp_file_btn.UseVisualStyleBackColor = true;
            this.form_bsp_file_btn.Click += new System.EventHandler(this.form_bsp_file_btn_Click);
            // 
            // form_bsp_file_txtbox
            // 
            this.form_bsp_file_txtbox.Location = new System.Drawing.Point(93, 31);
            this.form_bsp_file_txtbox.MaxLength = 1024;
            this.form_bsp_file_txtbox.Name = "form_bsp_file_txtbox";
            this.form_bsp_file_txtbox.Size = new System.Drawing.Size(294, 20);
            this.form_bsp_file_txtbox.TabIndex = 1;
            // 
            // bsp_file_dlg
            // 
            this.bsp_file_dlg.FileName = "openFileDialog1";
            // 
            // form_bsp_file_label
            // 
            this.form_bsp_file_label.AutoSize = true;
            this.form_bsp_file_label.Location = new System.Drawing.Point(90, 15);
            this.form_bsp_file_label.Name = "form_bsp_file_label";
            this.form_bsp_file_label.Size = new System.Drawing.Size(50, 13);
            this.form_bsp_file_label.TabIndex = 2;
            this.form_bsp_file_label.Text = ".BSP File";
            // 
            // form_lmp_file_btn
            // 
            this.form_lmp_file_btn.AutoSize = true;
            this.form_lmp_file_btn.Location = new System.Drawing.Point(12, 86);
            this.form_lmp_file_btn.Name = "form_lmp_file_btn";
            this.form_lmp_file_btn.Size = new System.Drawing.Size(75, 23);
            this.form_lmp_file_btn.TabIndex = 3;
            this.form_lmp_file_btn.Text = "Browse";
            this.form_lmp_file_btn.UseVisualStyleBackColor = true;
            this.form_lmp_file_btn.Click += new System.EventHandler(this.form_lmp_file_btn_Click);
            // 
            // form_lmp_file_txtbox
            // 
            this.form_lmp_file_txtbox.Location = new System.Drawing.Point(93, 89);
            this.form_lmp_file_txtbox.MaxLength = 1024;
            this.form_lmp_file_txtbox.Name = "form_lmp_file_txtbox";
            this.form_lmp_file_txtbox.Size = new System.Drawing.Size(294, 20);
            this.form_lmp_file_txtbox.TabIndex = 4;
            // 
            // form_lmp_file_label
            // 
            this.form_lmp_file_label.AutoSize = true;
            this.form_lmp_file_label.Location = new System.Drawing.Point(93, 73);
            this.form_lmp_file_label.Name = "form_lmp_file_label";
            this.form_lmp_file_label.Size = new System.Drawing.Size(51, 13);
            this.form_lmp_file_label.TabIndex = 5;
            this.form_lmp_file_label.Text = ".LMP File";
            // 
            // lmp_file_dlg
            // 
            this.lmp_file_dlg.FileName = "openFileDialog1";
            // 
            // form_start_stich_btn
            // 
            this.form_start_stich_btn.AutoSize = true;
            this.form_start_stich_btn.Location = new System.Drawing.Point(12, 133);
            this.form_start_stich_btn.Name = "form_start_stich_btn";
            this.form_start_stich_btn.Size = new System.Drawing.Size(107, 33);
            this.form_start_stich_btn.TabIndex = 6;
            this.form_start_stich_btn.Text = "Execute";
            this.form_start_stich_btn.UseVisualStyleBackColor = true;
            this.form_start_stich_btn.Click += new System.EventHandler(this.form_start_stich_btn_Click);
            // 
            // form_warning_log_txtbox
            // 
            this.form_warning_log_txtbox.AutoSize = true;
            this.form_warning_log_txtbox.ForeColor = System.Drawing.Color.DarkOrange;
            this.form_warning_log_txtbox.Location = new System.Drawing.Point(311, 182);
            this.form_warning_log_txtbox.Name = "form_warning_log_txtbox";
            this.form_warning_log_txtbox.Size = new System.Drawing.Size(55, 13);
            this.form_warning_log_txtbox.TabIndex = 8;
            this.form_warning_log_txtbox.Text = "Warnings:";
            // 
            // form_error_log_txtbox
            // 
            this.form_error_log_txtbox.AutoSize = true;
            this.form_error_log_txtbox.ForeColor = System.Drawing.Color.Firebrick;
            this.form_error_log_txtbox.Location = new System.Drawing.Point(204, 182);
            this.form_error_log_txtbox.Name = "form_error_log_txtbox";
            this.form_error_log_txtbox.Size = new System.Drawing.Size(37, 13);
            this.form_error_log_txtbox.TabIndex = 9;
            this.form_error_log_txtbox.Text = "Errors:";
            // 
            // form_error_log_counter
            // 
            this.form_error_log_counter.AutoSize = true;
            this.form_error_log_counter.ForeColor = System.Drawing.Color.Firebrick;
            this.form_error_log_counter.Location = new System.Drawing.Point(245, 182);
            this.form_error_log_counter.Name = "form_error_log_counter";
            this.form_error_log_counter.Size = new System.Drawing.Size(13, 13);
            this.form_error_log_counter.TabIndex = 10;
            this.form_error_log_counter.Text = "0";
            // 
            // form_warning_log_counter
            // 
            this.form_warning_log_counter.AutoSize = true;
            this.form_warning_log_counter.ForeColor = System.Drawing.Color.DarkOrange;
            this.form_warning_log_counter.Location = new System.Drawing.Point(372, 182);
            this.form_warning_log_counter.Name = "form_warning_log_counter";
            this.form_warning_log_counter.Size = new System.Drawing.Size(13, 13);
            this.form_warning_log_counter.TabIndex = 11;
            this.form_warning_log_counter.Text = "0";
            // 
            // form_exec_log_listbox
            // 
            this.form_exec_log_listbox.FormattingEnabled = true;
            this.form_exec_log_listbox.Location = new System.Drawing.Point(12, 198);
            this.form_exec_log_listbox.Name = "form_exec_log_listbox";
            this.form_exec_log_listbox.Size = new System.Drawing.Size(375, 108);
            this.form_exec_log_listbox.TabIndex = 12;
            // 
            // form_credit_tab_btn
            // 
            this.form_credit_tab_btn.Location = new System.Drawing.Point(312, 143);
            this.form_credit_tab_btn.Name = "form_credit_tab_btn";
            this.form_credit_tab_btn.Size = new System.Drawing.Size(75, 23);
            this.form_credit_tab_btn.TabIndex = 13;
            this.form_credit_tab_btn.Text = "More...";
            this.form_credit_tab_btn.UseVisualStyleBackColor = true;
            this.form_credit_tab_btn.Click += new System.EventHandler(this.form_credit_tab_btn_Click);
            // 
            // form_bsph_log_listbox
            // 
            this.form_bsph_log_listbox.FormattingEnabled = true;
            this.form_bsph_log_listbox.Location = new System.Drawing.Point(12, 331);
            this.form_bsph_log_listbox.Name = "form_bsph_log_listbox";
            this.form_bsph_log_listbox.Size = new System.Drawing.Size(375, 82);
            this.form_bsph_log_listbox.TabIndex = 14;
            // 
            // form_exec_log_label
            // 
            this.form_exec_log_label.AutoSize = true;
            this.form_exec_log_label.Location = new System.Drawing.Point(9, 182);
            this.form_exec_log_label.Name = "form_exec_log_label";
            this.form_exec_log_label.Size = new System.Drawing.Size(78, 13);
            this.form_exec_log_label.TabIndex = 15;
            this.form_exec_log_label.Text = "Execution Log:";
            // 
            // form_bsph_label
            // 
            this.form_bsph_label.AutoSize = true;
            this.form_bsph_label.Location = new System.Drawing.Point(9, 315);
            this.form_bsph_label.Name = "form_bsph_label";
            this.form_bsph_label.Size = new System.Drawing.Size(124, 13);
            this.form_bsph_label.TabIndex = 16;
            this.form_bsph_label.Text = "BSP Header Information:";
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 436);
            this.Controls.Add(this.form_bsph_label);
            this.Controls.Add(this.form_exec_log_label);
            this.Controls.Add(this.form_bsph_log_listbox);
            this.Controls.Add(this.form_credit_tab_btn);
            this.Controls.Add(this.form_exec_log_listbox);
            this.Controls.Add(this.form_warning_log_counter);
            this.Controls.Add(this.form_error_log_counter);
            this.Controls.Add(this.form_error_log_txtbox);
            this.Controls.Add(this.form_warning_log_txtbox);
            this.Controls.Add(this.form_start_stich_btn);
            this.Controls.Add(this.form_lmp_file_label);
            this.Controls.Add(this.form_lmp_file_txtbox);
            this.Controls.Add(this.form_lmp_file_btn);
            this.Controls.Add(this.form_bsp_file_label);
            this.Controls.Add(this.form_bsp_file_txtbox);
            this.Controls.Add(this.form_bsp_file_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(415, 475);
            this.Name = "form_main";
            this.Text = "LumpStich";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button form_bsp_file_btn;
        private System.Windows.Forms.TextBox form_bsp_file_txtbox;
        private System.Windows.Forms.OpenFileDialog bsp_file_dlg;
        private System.Windows.Forms.Label form_bsp_file_label;
        private System.Windows.Forms.Button form_lmp_file_btn;
        private System.Windows.Forms.TextBox form_lmp_file_txtbox;
        private System.Windows.Forms.Label form_lmp_file_label;
        private System.Windows.Forms.OpenFileDialog lmp_file_dlg;
        private System.Windows.Forms.Button form_start_stich_btn;
        private System.Windows.Forms.Label form_warning_log_txtbox;
        private System.Windows.Forms.Label form_error_log_txtbox;
        private System.Windows.Forms.Button form_credit_tab_btn;
        private System.Windows.Forms.Label form_exec_log_label;
        private System.Windows.Forms.Label form_bsph_label;
        private System.Windows.Forms.ListBox form_exec_log_listbox;
        private System.Windows.Forms.Label form_error_log_counter;
        private System.Windows.Forms.Label form_warning_log_counter;
        private System.Windows.Forms.ListBox form_bsph_log_listbox;
    }
}

