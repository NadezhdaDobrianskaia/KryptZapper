namespace KryptZapper
{
    partial class FormChild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChild));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.UserControlEncrypDecryp = new NadiaUserControl.NadiaUserControl();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(2, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(389, 175);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // UserControlEncrypDecryp
            // 
            this.UserControlEncrypDecryp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.UserControlEncrypDecryp.Location = new System.Drawing.Point(93, 181);
            this.UserControlEncrypDecryp.Name = "UserControlEncrypDecryp";
            this.UserControlEncrypDecryp.Size = new System.Drawing.Size(207, 119);
            this.UserControlEncrypDecryp.TabIndex = 1;
            this.UserControlEncrypDecryp.NadiaEncryption_Click += new NadiaUserControl.NadiaClickHandler(this.UserControlEncrypDecryp_NadiaEncryption_Click);
            this.UserControlEncrypDecryp.NadiaDecryption_Click += new NadiaUserControl.NadiaClickHandler(this.UserControlEncrypDecryp_NadiaDecryption_Click);
            this.UserControlEncrypDecryp.Load += new System.EventHandler(this.UserControlEncrypDecryp_Load);
            // 
            // FormChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 312);
            this.Controls.Add(this.UserControlEncrypDecryp);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChild";
            this.Text = "New File";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingChildForm);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private NadiaUserControl.NadiaUserControl UserControlEncrypDecryp;
    }
}