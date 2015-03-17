namespace KryptZapper
{
    partial class EmailMethodChooseDialog
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
            this.localEmailClientRadio = new System.Windows.Forms.RadioButton();
            this.smtpRadio = new System.Windows.Forms.RadioButton();
            this.methodOkayButton = new System.Windows.Forms.Button();
            this.methodCancelButton = new System.Windows.Forms.Button();
            this.setAsDefaultCheckbox = new System.Windows.Forms.CheckBox();
            this.methodLabel = new System.Windows.Forms.Label();
            this.setupQuestionLabel = new System.Windows.Forms.Label();
            this.linkToSetup = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // localEmailClientRadio
            // 
            this.localEmailClientRadio.AutoSize = true;
            this.localEmailClientRadio.Location = new System.Drawing.Point(22, 28);
            this.localEmailClientRadio.Name = "localEmailClientRadio";
            this.localEmailClientRadio.Size = new System.Drawing.Size(156, 17);
            this.localEmailClientRadio.TabIndex = 0;
            this.localEmailClientRadio.TabStop = true;
            this.localEmailClientRadio.Text = "using your local email client ";
            this.localEmailClientRadio.UseVisualStyleBackColor = true;
            // 
            // smtpRadio
            // 
            this.smtpRadio.AutoSize = true;
            this.smtpRadio.Location = new System.Drawing.Point(22, 64);
            this.smtpRadio.Name = "smtpRadio";
            this.smtpRadio.Size = new System.Drawing.Size(172, 17);
            this.smtpRadio.TabIndex = 1;
            this.smtpRadio.TabStop = true;
            this.smtpRadio.Text = "using configured email account";
            this.smtpRadio.UseVisualStyleBackColor = true;
            // 
            // methodOkayButton
            // 
            this.methodOkayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.methodOkayButton.Location = new System.Drawing.Point(77, 196);
            this.methodOkayButton.Name = "methodOkayButton";
            this.methodOkayButton.Size = new System.Drawing.Size(75, 23);
            this.methodOkayButton.TabIndex = 2;
            this.methodOkayButton.Text = "OK";
            this.methodOkayButton.UseVisualStyleBackColor = true;
            // 
            // methodCancelButton
            // 
            this.methodCancelButton.Location = new System.Drawing.Point(186, 196);
            this.methodCancelButton.Name = "methodCancelButton";
            this.methodCancelButton.Size = new System.Drawing.Size(75, 23);
            this.methodCancelButton.TabIndex = 3;
            this.methodCancelButton.Text = "Cancel";
            this.methodCancelButton.UseVisualStyleBackColor = true;
            // 
            // setAsDefaultCheckbox
            // 
            this.setAsDefaultCheckbox.AutoSize = true;
            this.setAsDefaultCheckbox.Location = new System.Drawing.Point(21, 250);
            this.setAsDefaultCheckbox.Name = "setAsDefaultCheckbox";
            this.setAsDefaultCheckbox.Size = new System.Drawing.Size(291, 17);
            this.setAsDefaultCheckbox.TabIndex = 4;
            this.setAsDefaultCheckbox.Text = "Do you want to set this as your default emailing method?";
            this.setAsDefaultCheckbox.UseVisualStyleBackColor = true;
            // 
            // methodLabel
            // 
            this.methodLabel.AutoSize = true;
            this.methodLabel.Location = new System.Drawing.Point(9, 19);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(189, 13);
            this.methodLabel.TabIndex = 5;
            this.methodLabel.Text = "How would you like to send this email?";
            // 
            // setupQuestionLabel
            // 
            this.setupQuestionLabel.AutoSize = true;
            this.setupQuestionLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.setupQuestionLabel.Location = new System.Drawing.Point(40, 93);
            this.setupQuestionLabel.Name = "setupQuestionLabel";
            this.setupQuestionLabel.Size = new System.Drawing.Size(217, 13);
            this.setupQuestionLabel.TabIndex = 6;
            this.setupQuestionLabel.Text = "Haven\'t set up your email account yet? Click";
            // 
            // linkToSetup
            // 
            this.linkToSetup.AutoSize = true;
            this.linkToSetup.Location = new System.Drawing.Point(252, 93);
            this.linkToSetup.Name = "linkToSetup";
            this.linkToSetup.Size = new System.Drawing.Size(31, 13);
            this.linkToSetup.TabIndex = 7;
            this.linkToSetup.TabStop = true;
            this.linkToSetup.Text = "here.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.localEmailClientRadio);
            this.groupBox1.Controls.Add(this.linkToSetup);
            this.groupBox1.Controls.Add(this.smtpRadio);
            this.groupBox1.Controls.Add(this.setupQuestionLabel);
            this.groupBox1.Location = new System.Drawing.Point(21, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 124);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // EmailMethodChooseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 281);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.methodLabel);
            this.Controls.Add(this.setAsDefaultCheckbox);
            this.Controls.Add(this.methodCancelButton);
            this.Controls.Add(this.methodOkayButton);
            this.Name = "EmailMethodChooseDialog";
            this.Text = "Email Method";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton localEmailClientRadio;
        private System.Windows.Forms.RadioButton smtpRadio;
        private System.Windows.Forms.Button methodOkayButton;
        private System.Windows.Forms.Button methodCancelButton;
        private System.Windows.Forms.CheckBox setAsDefaultCheckbox;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.Label setupQuestionLabel;
        private System.Windows.Forms.LinkLabel linkToSetup;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}