namespace KryptZapper
{
    partial class AboutDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.buttonOk = new System.Windows.Forms.Button();
            this.richTextBoxAbout = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonOk.Location = new System.Drawing.Point(107, 271);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonOk.Size = new System.Drawing.Size(125, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // richTextBoxAbout
            // 
            this.richTextBoxAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAbout.BackColor = System.Drawing.SystemColors.HighlightText;
            this.richTextBoxAbout.Location = new System.Drawing.Point(13, 12);
            this.richTextBoxAbout.Name = "richTextBoxAbout";
            this.richTextBoxAbout.ReadOnly = true;
            this.richTextBoxAbout.Size = new System.Drawing.Size(309, 253);
            this.richTextBoxAbout.TabIndex = 2;
            this.richTextBoxAbout.Text = "The about Text will go here";
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 306);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.richTextBoxAbout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "AboutDialog";
            this.Text = "About Krypt-Zapper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.RichTextBox richTextBoxAbout;
    }
}