namespace CopyThatProgram
{
    partial class smsForm
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
            sendSMSGroupBox = new GroupBox();
            phoneValidationLabel = new Label();
            smsMessageTextBox = new TextBox();
            smsMessageLabel = new Label();
            twilioPhoneNumberTextBox = new TextBox();
            twilioPhoneNumberLabel = new Label();
            twilioAuthTokenTextBox = new TextBox();
            twilioAuthTokenLabel = new Label();
            twilioAccountSIDTextBox = new TextBox();
            twilioAccountSIDLabel = new Label();
            phoneNumberTextBox = new TextBox();
            phoneNumberLabel = new Label();
            validatePhoneButton = new Button();
            testSMSButton = new Button();
            sendSMSButton = new Button();
            clearFieldsButton = new Button();
            exitPicBox = new PictureBox();
            sendSMSGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exitPicBox).BeginInit();
            SuspendLayout();
            // 
            // sendSMSGroupBox
            // 
            sendSMSGroupBox.Controls.Add(phoneValidationLabel);
            sendSMSGroupBox.Controls.Add(smsMessageTextBox);
            sendSMSGroupBox.Controls.Add(smsMessageLabel);
            sendSMSGroupBox.Controls.Add(twilioPhoneNumberTextBox);
            sendSMSGroupBox.Controls.Add(twilioPhoneNumberLabel);
            sendSMSGroupBox.Controls.Add(twilioAuthTokenTextBox);
            sendSMSGroupBox.Controls.Add(twilioAuthTokenLabel);
            sendSMSGroupBox.Controls.Add(twilioAccountSIDTextBox);
            sendSMSGroupBox.Controls.Add(twilioAccountSIDLabel);
            sendSMSGroupBox.Controls.Add(phoneNumberTextBox);
            sendSMSGroupBox.Controls.Add(phoneNumberLabel);
            sendSMSGroupBox.Controls.Add(validatePhoneButton);
            sendSMSGroupBox.Controls.Add(testSMSButton);
            sendSMSGroupBox.Controls.Add(sendSMSButton);
            sendSMSGroupBox.Controls.Add(clearFieldsButton);
            sendSMSGroupBox.ForeColor = Color.Black;
            sendSMSGroupBox.Location = new Point(32, 105);
            sendSMSGroupBox.Name = "sendSMSGroupBox";
            sendSMSGroupBox.Size = new Size(776, 550);
            sendSMSGroupBox.TabIndex = 77;
            sendSMSGroupBox.TabStop = false;
            sendSMSGroupBox.Text = "SMS Settings:";
            // 
            // phoneValidationLabel
            // 
            phoneValidationLabel.AutoSize = true;
            phoneValidationLabel.Location = new Point(269, 72);
            phoneValidationLabel.Name = "phoneValidationLabel";
            phoneValidationLabel.Size = new Size(0, 25);
            phoneValidationLabel.TabIndex = 108;
            // 
            // smsMessageTextBox
            // 
            smsMessageTextBox.BorderStyle = BorderStyle.FixedSingle;
            smsMessageTextBox.Location = new Point(14, 315);
            smsMessageTextBox.MaxLength = 300;
            smsMessageTextBox.Multiline = true;
            smsMessageTextBox.Name = "smsMessageTextBox";
            smsMessageTextBox.PlaceholderText = "Optional custom message to include before operation summary...";
            smsMessageTextBox.Size = new Size(756, 110);
            smsMessageTextBox.TabIndex = 105;
            // 
            // smsMessageLabel
            // 
            smsMessageLabel.AutoSize = true;
            smsMessageLabel.Location = new Point(14, 287);
            smsMessageLabel.Name = "smsMessageLabel";
            smsMessageLabel.Size = new Size(229, 25);
            smsMessageLabel.TabIndex = 104;
            smsMessageLabel.Text = "Custom SMS Message Text:";
            // 
            // twilioPhoneNumberTextBox
            // 
            twilioPhoneNumberTextBox.BorderStyle = BorderStyle.FixedSingle;
            twilioPhoneNumberTextBox.Location = new Point(269, 246);
            twilioPhoneNumberTextBox.MaxLength = 20;
            twilioPhoneNumberTextBox.Name = "twilioPhoneNumberTextBox";
            twilioPhoneNumberTextBox.PlaceholderText = "+1234567890";
            twilioPhoneNumberTextBox.Size = new Size(300, 31);
            twilioPhoneNumberTextBox.TabIndex = 102;
            // 
            // twilioPhoneNumberLabel
            // 
            twilioPhoneNumberLabel.AutoSize = true;
            twilioPhoneNumberLabel.Location = new Point(14, 248);
            twilioPhoneNumberLabel.Name = "twilioPhoneNumberLabel";
            twilioPhoneNumberLabel.Size = new Size(185, 25);
            twilioPhoneNumberLabel.TabIndex = 101;
            twilioPhoneNumberLabel.Text = "Twilio Phone Number:";
            // 
            // twilioAuthTokenTextBox
            // 
            twilioAuthTokenTextBox.BorderStyle = BorderStyle.FixedSingle;
            twilioAuthTokenTextBox.Location = new Point(269, 177);
            twilioAuthTokenTextBox.MaxLength = 80;
            twilioAuthTokenTextBox.Name = "twilioAuthTokenTextBox";
            twilioAuthTokenTextBox.PasswordChar = '*';
            twilioAuthTokenTextBox.Size = new Size(501, 31);
            twilioAuthTokenTextBox.TabIndex = 100;
            // 
            // twilioAuthTokenLabel
            // 
            twilioAuthTokenLabel.AutoSize = true;
            twilioAuthTokenLabel.Location = new Point(14, 183);
            twilioAuthTokenLabel.Name = "twilioAuthTokenLabel";
            twilioAuthTokenLabel.Size = new Size(154, 25);
            twilioAuthTokenLabel.TabIndex = 99;
            twilioAuthTokenLabel.Text = "Twilio Auth Token:";
            // 
            // twilioAccountSIDTextBox
            // 
            twilioAccountSIDTextBox.BorderStyle = BorderStyle.FixedSingle;
            twilioAccountSIDTextBox.Location = new Point(269, 108);
            twilioAccountSIDTextBox.MaxLength = 80;
            twilioAccountSIDTextBox.Name = "twilioAccountSIDTextBox";
            twilioAccountSIDTextBox.Size = new Size(501, 31);
            twilioAccountSIDTextBox.TabIndex = 98;
            // 
            // twilioAccountSIDLabel
            // 
            twilioAccountSIDLabel.AutoSize = true;
            twilioAccountSIDLabel.Location = new Point(14, 114);
            twilioAccountSIDLabel.Name = "twilioAccountSIDLabel";
            twilioAccountSIDLabel.Size = new Size(163, 25);
            twilioAccountSIDLabel.TabIndex = 97;
            twilioAccountSIDLabel.Text = "Twilio Account SID:";
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.BorderStyle = BorderStyle.FixedSingle;
            phoneNumberTextBox.Location = new Point(313, 39);
            phoneNumberTextBox.MaxLength = 20;
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.PlaceholderText = "+1234567890";
            phoneNumberTextBox.Size = new Size(320, 31);
            phoneNumberTextBox.TabIndex = 96;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(14, 41);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(293, 25);
            phoneNumberLabel.TabIndex = 95;
            phoneNumberLabel.Text = "Phone Number (with country code):";
            // 
            // validatePhoneButton
            // 
            validatePhoneButton.BackColor = SystemColors.Control;
            validatePhoneButton.ForeColor = Color.Black;
            validatePhoneButton.Location = new Point(639, 36);
            validatePhoneButton.Name = "validatePhoneButton";
            validatePhoneButton.Size = new Size(120, 34);
            validatePhoneButton.TabIndex = 106;
            validatePhoneButton.Text = "Validate";
            validatePhoneButton.UseVisualStyleBackColor = false;
            validatePhoneButton.Click += validatePhoneButton_Click;
            // 
            // testSMSButton
            // 
            testSMSButton.BackColor = SystemColors.Control;
            testSMSButton.ForeColor = Color.Black;
            testSMSButton.Location = new Point(304, 461);
            testSMSButton.Name = "testSMSButton";
            testSMSButton.Size = new Size(175, 34);
            testSMSButton.TabIndex = 107;
            testSMSButton.Text = "Send Test SMS";
            testSMSButton.UseVisualStyleBackColor = false;
            testSMSButton.Click += testSMSButton_Click;
            // 
            // sendSMSButton
            // 
            sendSMSButton.BackColor = SystemColors.Control;
            sendSMSButton.ForeColor = Color.Black;
            sendSMSButton.Location = new Point(14, 461);
            sendSMSButton.Name = "sendSMSButton";
            sendSMSButton.Size = new Size(175, 34);
            sendSMSButton.TabIndex = 91;
            sendSMSButton.Text = "Save Settings";
            sendSMSButton.UseVisualStyleBackColor = false;
            sendSMSButton.Click += sendSMSButton_Click;
            // 
            // clearFieldsButton
            // 
            clearFieldsButton.BackColor = SystemColors.Control;
            clearFieldsButton.ForeColor = Color.Black;
            clearFieldsButton.Location = new Point(594, 461);
            clearFieldsButton.Name = "clearFieldsButton";
            clearFieldsButton.Size = new Size(175, 34);
            clearFieldsButton.TabIndex = 103;
            clearFieldsButton.Text = "Clear Fields";
            clearFieldsButton.UseVisualStyleBackColor = false;
            clearFieldsButton.Click += clearFieldsButton_Click;
            // 
            // smsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 707);
            Controls.Add(sendSMSGroupBox);
            Controls.Add(exitPicBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "smsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SMS Notification Setup";
            Load += SMSForm_Load;
            sendSMSGroupBox.ResumeLayout(false);
            sendSMSGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)exitPicBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox sendSMSGroupBox;
        private Label phoneNumberLabel;
        private TextBox phoneNumberTextBox;
        private Label twilioAccountSIDLabel;
        private TextBox twilioAccountSIDTextBox;
        private Label twilioAuthTokenLabel;
        private TextBox twilioAuthTokenTextBox;
        private Label twilioPhoneNumberLabel;
        private TextBox twilioPhoneNumberTextBox;
        private Label smsMessageLabel;
        private TextBox smsMessageTextBox;
        private Button validatePhoneButton;
        private Button testSMSButton;
        private Button sendSMSButton;
        private Button clearFieldsButton;
        private Label phoneValidationLabel;
        private PictureBox exitPicBox;
    }
}