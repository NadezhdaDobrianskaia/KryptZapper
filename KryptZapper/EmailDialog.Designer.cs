namespace KryptZapper
{
    partial class EmailDialog
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
            this.emailEmailLabel = new System.Windows.Forms.Label();
            this.emailRecipientText = new System.Windows.Forms.TextBox();
            this.emailSendButton = new System.Windows.Forms.Button();
            this.emailCanelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // emailEmailLabel
            // 
            this.emailEmailLabel.AutoSize = true;
            this.emailEmailLabel.Location = new System.Drawing.Point(26, 31);
            this.emailEmailLabel.Name = "emailEmailLabel";
            this.emailEmailLabel.Size = new System.Drawing.Size(90, 13);
            this.emailEmailLabel.TabIndex = 0;
            this.emailEmailLabel.Text = "Recipient\'s Email:";
            // 
            // emailRecipientText
            // 
            this.emailRecipientText.Location = new System.Drawing.Point(122, 28);
            this.emailRecipientText.Name = "emailRecipientText";
            this.emailRecipientText.Size = new System.Drawing.Size(344, 20);
            this.emailRecipientText.TabIndex = 2;
            // 
            // emailSendButton
            // 
            this.emailSendButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.emailSendButton.Location = new System.Drawing.Point(152, 81);
            this.emailSendButton.Name = "emailSendButton";
            this.emailSendButton.Size = new System.Drawing.Size(75, 23);
            this.emailSendButton.TabIndex = 3;
            this.emailSendButton.Text = "Send";
            this.emailSendButton.UseVisualStyleBackColor = true;
            // 
            // emailCanelButton
            // 
            this.emailCanelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.emailCanelButton.Location = new System.Drawing.Point(277, 81);
            this.emailCanelButton.Name = "emailCanelButton";
            this.emailCanelButton.Size = new System.Drawing.Size(75, 23);
            this.emailCanelButton.TabIndex = 4;
            this.emailCanelButton.Text = "Cancel";
            this.emailCanelButton.UseVisualStyleBackColor = true;
            // 
            // EmailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 133);
            this.Controls.Add(this.emailCanelButton);
            this.Controls.Add(this.emailSendButton);
            this.Controls.Add(this.emailRecipientText);
            this.Controls.Add(this.emailEmailLabel);
            this.Name = "EmailDialog";
            this.Text = "Email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emailEmailLabel;
        private System.Windows.Forms.TextBox emailRecipientText;
        private System.Windows.Forms.Button emailSendButton;
        private System.Windows.Forms.Button emailCanelButton;
    }
}