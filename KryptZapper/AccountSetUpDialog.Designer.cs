namespace KryptZapper
{
    partial class AccountSetUpDialog
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
            this.setupUsernameLabel = new System.Windows.Forms.Label();
            this.setupHostLabel = new System.Windows.Forms.Label();
            this.setupPortLabel = new System.Windows.Forms.Label();
            this.setupOKButton = new System.Windows.Forms.Button();
            this.setupHostText = new System.Windows.Forms.TextBox();
            this.setupPortText = new System.Windows.Forms.TextBox();
            this.setupUsernameText = new System.Windows.Forms.TextBox();
            this.setupCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // setupUsernameLabel
            // 
            this.setupUsernameLabel.AutoSize = true;
            this.setupUsernameLabel.Location = new System.Drawing.Point(30, 105);
            this.setupUsernameLabel.Name = "setupUsernameLabel";
            this.setupUsernameLabel.Size = new System.Drawing.Size(58, 13);
            this.setupUsernameLabel.TabIndex = 0;
            this.setupUsernameLabel.Text = "Username:";
            // 
            // setupHostLabel
            // 
            this.setupHostLabel.AutoSize = true;
            this.setupHostLabel.Location = new System.Drawing.Point(27, 29);
            this.setupHostLabel.Name = "setupHostLabel";
            this.setupHostLabel.Size = new System.Drawing.Size(32, 13);
            this.setupHostLabel.TabIndex = 1;
            this.setupHostLabel.Text = "Host:";
            // 
            // setupPortLabel
            // 
            this.setupPortLabel.AutoSize = true;
            this.setupPortLabel.Location = new System.Drawing.Point(30, 67);
            this.setupPortLabel.Name = "setupPortLabel";
            this.setupPortLabel.Size = new System.Drawing.Size(29, 13);
            this.setupPortLabel.TabIndex = 2;
            this.setupPortLabel.Text = "Port:";
            // 
            // setupOKButton
            // 
            this.setupOKButton.Location = new System.Drawing.Point(81, 157);
            this.setupOKButton.Name = "setupOKButton";
            this.setupOKButton.Size = new System.Drawing.Size(75, 23);
            this.setupOKButton.TabIndex = 3;
            this.setupOKButton.Text = "Submit";
            this.setupOKButton.UseVisualStyleBackColor = true;
            // 
            // setupHostText
            // 
            this.setupHostText.Location = new System.Drawing.Point(101, 29);
            this.setupHostText.Name = "setupHostText";
            this.setupHostText.Size = new System.Drawing.Size(214, 20);
            this.setupHostText.TabIndex = 4;
            // 
            // setupPortText
            // 
            this.setupPortText.Location = new System.Drawing.Point(101, 67);
            this.setupPortText.Name = "setupPortText";
            this.setupPortText.Size = new System.Drawing.Size(214, 20);
            this.setupPortText.TabIndex = 5;
            // 
            // setupUsernameText
            // 
            this.setupUsernameText.Location = new System.Drawing.Point(101, 105);
            this.setupUsernameText.Name = "setupUsernameText";
            this.setupUsernameText.Size = new System.Drawing.Size(214, 20);
            this.setupUsernameText.TabIndex = 6;
            // 
            // setupCancelButton
            // 
            this.setupCancelButton.Location = new System.Drawing.Point(190, 157);
            this.setupCancelButton.Name = "setupCancelButton";
            this.setupCancelButton.Size = new System.Drawing.Size(75, 23);
            this.setupCancelButton.TabIndex = 7;
            this.setupCancelButton.Text = "Cancel";
            this.setupCancelButton.UseVisualStyleBackColor = true;
            // 
            // AccountSetUpDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 207);
            this.Controls.Add(this.setupCancelButton);
            this.Controls.Add(this.setupUsernameText);
            this.Controls.Add(this.setupPortText);
            this.Controls.Add(this.setupHostText);
            this.Controls.Add(this.setupOKButton);
            this.Controls.Add(this.setupPortLabel);
            this.Controls.Add(this.setupHostLabel);
            this.Controls.Add(this.setupUsernameLabel);
            this.Name = "AccountSetUpDialog";
            this.Text = "Account Set Up";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label setupUsernameLabel;
        private System.Windows.Forms.Label setupHostLabel;
        private System.Windows.Forms.Label setupPortLabel;
        private System.Windows.Forms.Button setupOKButton;
        private System.Windows.Forms.TextBox setupHostText;
        private System.Windows.Forms.TextBox setupPortText;
        private System.Windows.Forms.TextBox setupUsernameText;
        private System.Windows.Forms.Button setupCancelButton;
    }
}