namespace LumpStich
{
    partial class form2_main_window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form2_main_window));
            this.form2_credit_label = new System.Windows.Forms.Label();
            this.form2_credit_link = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // form2_credit_label
            // 
            this.form2_credit_label.AutoSize = true;
            this.form2_credit_label.Location = new System.Drawing.Point(33, 21);
            this.form2_credit_label.Name = "form2_credit_label";
            this.form2_credit_label.Size = new System.Drawing.Size(149, 13);
            this.form2_credit_label.TabIndex = 0;
            this.form2_credit_label.Text = "LumpStich -  Made by Rim032";
            // 
            // form2_credit_link
            // 
            this.form2_credit_link.AutoSize = true;
            this.form2_credit_link.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.form2_credit_link.Location = new System.Drawing.Point(40, 39);
            this.form2_credit_link.Name = "form2_credit_link";
            this.form2_credit_link.Size = new System.Drawing.Size(136, 13);
            this.form2_credit_link.TabIndex = 1;
            this.form2_credit_link.TabStop = true;
            this.form2_credit_link.Text = "https://github.com/Rim032";
            this.form2_credit_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.form2_credit_link_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Keep learning.";
            // 
            // form2_main_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 121);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.form2_credit_link);
            this.Controls.Add(this.form2_credit_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(237, 160);
            this.MinimumSize = new System.Drawing.Size(237, 160);
            this.Name = "form2_main_window";
            this.Text = "More";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label form2_credit_label;
        private System.Windows.Forms.LinkLabel form2_credit_link;
        private System.Windows.Forms.Label label1;
    }
}