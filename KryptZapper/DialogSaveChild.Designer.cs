namespace KryptZapper
{
    partial class DialogSaveChild
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.DialogSaveChildLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(34, 78);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonCancel.Location = new System.Drawing.Point(136, 78);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "No";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // DialogSaveChildLabel
            // 
            this.DialogSaveChildLabel.AutoSize = true;
            this.DialogSaveChildLabel.Location = new System.Drawing.Point(63, 33);
            this.DialogSaveChildLabel.Name = "DialogSaveChildLabel";
            this.DialogSaveChildLabel.Size = new System.Drawing.Size(121, 13);
            this.DialogSaveChildLabel.TabIndex = 3;
            this.DialogSaveChildLabel.Text = "Would you like to save?";
            this.DialogSaveChildLabel.Click += new System.EventHandler(this.DialogSaveChildLabel_Click);
            // 
            // DialogSaveChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 124);
            this.Controls.Add(this.DialogSaveChildLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "DialogSaveChild";
            this.Text = "Save File ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label DialogSaveChildLabel;
    }
}