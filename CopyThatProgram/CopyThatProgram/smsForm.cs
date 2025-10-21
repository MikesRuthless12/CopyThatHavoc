using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CopyThatProgram
{
    public partial class smsForm : Form
    {
        private mainForm main;

        public smsForm()
        {
            InitializeComponent();
            main = new mainForm();
            //LoadSavedSettings();
        }

        private void exitPicBox_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void validatePhoneButton_Click(object sender, EventArgs e)
        {
            string phoneNumber = phoneNumberTextBox.Text.Trim();
            bool isValid = ValidatePhoneNumber(phoneNumber);

            if (isValid)
            {
                phoneValidationLabel.Text = "✓ Valid phone number format";
                phoneValidationLabel.ForeColor = Color.Green;
            }
            else
            {
                phoneValidationLabel.Text = "✗ Invalid format. Use: +[country code][area code][number]";
                phoneValidationLabel.ForeColor = Color.Red;
            }
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            // Remove all whitespace and special characters except +
            string cleanNumber = Regex.Replace(phoneNumber, @"[^\+\d]", "");

            // Must start with + and have country code
            if (!cleanNumber.StartsWith("+"))
            {
                return false;
            }

            // Remove the + for length validation
            string numberOnly = cleanNumber.Substring(1);

            // Should be between 10-15 digits (international standard)
            if (numberOnly.Length < 10 || numberOnly.Length > 15)
            {
                return false;
            }

            // Must be all digits after the +
            if (!Regex.IsMatch(numberOnly, @"^\d+$"))
            {
                return false;
            }

            // Basic validation for common country codes and area codes
            // US/Canada: +1 followed by 10 digits
            if (cleanNumber.StartsWith("+1") && numberOnly.Length == 11)
            {
                return true;
            }

            // UK: +44 followed by 10-11 digits
            if (cleanNumber.StartsWith("+44") && (numberOnly.Length >= 12 && numberOnly.Length <= 13))
            {
                return true;
            }

            // Germany: +49 followed by 10-12 digits
            if (cleanNumber.StartsWith("+49") && (numberOnly.Length >= 12 && numberOnly.Length <= 14))
            {
                return true;
            }

            // France: +33 followed by 9 digits
            if (cleanNumber.StartsWith("+33") && numberOnly.Length == 12)
            {
                return true;
            }

            // Australia: +61 followed by 9 digits
            if (cleanNumber.StartsWith("+61") && numberOnly.Length == 12)
            {
                return true;
            }

            // Generic validation for other countries (10-15 digits total)
            return numberOnly.Length >= 10 && numberOnly.Length <= 15;
        }

        private void testSMSButton_Click(object sender, EventArgs e)
        {
            if (!ValidateAllFields())
            {
                return;
            }

            try
            {
                string accountSid = twilioAccountSIDTextBox.Text.Trim();
                string authToken = twilioAuthTokenTextBox.Text.Trim();
                string fromPhoneNumber = twilioPhoneNumberTextBox.Text.Trim();
                string toPhoneNumber = phoneNumberTextBox.Text.Trim();

                TwilioClient.Init(accountSid, authToken);

                string testMessage = "Test SMS from Copy That Program. SMS notifications are working correctly!";

                var message = MessageResource.Create(
                    body: testMessage,
                    from: new PhoneNumber(fromPhoneNumber),
                    to: new PhoneNumber(toPhoneNumber)
                );

                MessageBox.Show("Test SMS sent successfully! Check your phone.", "SMS Test Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending test SMS: {ex.Message}", "SMS Test Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendSMSButton_Click(object sender, EventArgs e)
        {
            if (!ValidateAllFields())
            {
                return;
            }

            //SaveSettings();
            MessageBox.Show("SMS settings saved successfully!", "Settings Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidateAllFields()
        {
            if (string.IsNullOrWhiteSpace(phoneNumberTextBox.Text))
            {
                MessageBox.Show("Please enter a phone number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidatePhoneNumber(phoneNumberTextBox.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid phone number with country code (e.g., +1234567890).",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(twilioAccountSIDTextBox.Text))
            {
                MessageBox.Show("Please enter your Twilio Account SID.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(twilioAuthTokenTextBox.Text))
            {
                MessageBox.Show("Please enter your Twilio Auth Token.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(twilioPhoneNumberTextBox.Text))
            {
                MessageBox.Show("Please enter your Twilio phone number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidatePhoneNumber(twilioPhoneNumberTextBox.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid Twilio phone number with country code.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        //public static void SendOperationSummaryNotification(string operationSummary)
        //{
        //    try
        //    {
        //        var settings = Properties.Settings.Default;

        //        if (string.IsNullOrWhiteSpace(settings.SMSPhoneNumber) ||
        //            string.IsNullOrWhiteSpace(settings.TwilioAccountSID) ||
        //            string.IsNullOrWhiteSpace(settings.TwilioAuthToken) ||
        //            string.IsNullOrWhiteSpace(settings.TwilioPhoneNumber))
        //        {
        //            return; // SMS not configured
        //        }

        //        TwilioClient.Init(settings.TwilioAccountSID, settings.TwilioAuthToken);

        //        string customMessage = !string.IsNullOrWhiteSpace(settings.SMSCustomMessage)
        //            ? settings.SMSCustomMessage + "\n\n"
        //            : "";

        //        string fullMessage = customMessage + operationSummary;

        //        // SMS has character limits, truncate if necessary
        //        if (fullMessage.Length > 1600)
        //        {
        //            fullMessage = fullMessage.Substring(0, 1597) + "...";
        //        }

        //        var message = MessageResource.Create(
        //            body: fullMessage,
        //            from: new PhoneNumber(settings.TwilioPhoneNumber),
        //            to: new PhoneNumber(settings.SMSPhoneNumber)
        //        );

        //        // Optional: Log successful SMS send
        //        System.Diagnostics.Debug.WriteLine($"SMS notification sent successfully to {settings.SMSPhoneNumber}");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log error but don't interrupt the main operation
        //        System.Diagnostics.Debug.WriteLine($"Failed to send SMS notification: {ex.Message}");
        //    }
        //}

        //private void SaveSettings()
        //{
        //    var settings = Properties.Settings.Default;
        //    settings.SMSPhoneNumber = phoneNumberTextBox.Text.Trim();
        //    settings.TwilioAccountSID = twilioAccountSIDTextBox.Text.Trim();
        //    settings.TwilioAuthToken = twilioAuthTokenTextBox.Text.Trim();
        //    settings.TwilioPhoneNumber = twilioPhoneNumberTextBox.Text.Trim();
        //    settings.SMSCustomMessage = smsMessageTextBox.Text.Trim();
        //    settings.Save();
        //}

        //private void LoadSavedSettings()
        //{
        //    var settings = Properties.Settings.Default;
        //    phoneNumberTextBox.Text = settings.SMSPhoneNumber ?? "";
        //    twilioAccountSIDTextBox.Text = settings.TwilioAccountSID ?? "";
        //    twilioAuthTokenTextBox.Text = settings.TwilioAuthToken ?? "";
        //    twilioPhoneNumberTextBox.Text = settings.TwilioPhoneNumber ?? "";
        //    smsMessageTextBox.Text = settings.SMSCustomMessage ?? "";
        //}

        private void clearFieldsButton_Click(object sender, EventArgs e)
        {
            phoneNumberTextBox.Clear();
            twilioAccountSIDTextBox.Clear();
            twilioAuthTokenTextBox.Clear();
            twilioPhoneNumberTextBox.Clear();
            smsMessageTextBox.Clear();
            phoneValidationLabel.Text = "";
        }

        private void ChangeControlsForeColor(Control control, Color newColor)
        {
            foreach (Control ctrl in control.Controls)
            {
                ctrl.ForeColor = newColor;

                if (ctrl.HasChildren)
                {
                    ChangeControlsForeColor(ctrl, newColor);
                }
            }
        }

        private void ChangeControlsBackColor(Control control, Color newColor)
        {
            foreach (Control ctrl in control.Controls)
            {
                ctrl.BackColor = newColor;

                if (ctrl.HasChildren)
                {
                    ChangeControlsBackColor(ctrl, newColor);
                }
            }
        }

        private Color GetContrastingColor(Color backColor)
        {
            // Calculate perceived brightness (human eye favors green)
            double brightness = (0.299 * backColor.R + 0.587 * backColor.G + 0.114 * backColor.B) / 255;

            // Return black or white based on brightness
            return brightness > 0.5 ? Color.Black : Color.White;
        }
        private void ChangeControlColorsLabelsCheckBoxes(Color newColor)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label || ctrl is CheckBox)
                {
                    ctrl.BackColor = newColor;
                }
            }
        }
        private void SMSForm_Load(object sender, EventArgs e)
        {
            string valueFromForm2 = main.GetStringVariable();

            if (valueFromForm2 == "Dark Mode")
            {

                ChangeControlsForeColor(this, Color.White);

                ChangeControlsBackColor(this, Color.Black);

                ChangeControlColorsLabelsCheckBoxes(Color.Transparent);

                this.BackColor = Color.Black;


            }
            else if ((valueFromForm2 == "Light Mode"))
            {
                ChangeControlsForeColor(this, Color.Black);

                ChangeControlsBackColor(this, Color.White);

                ChangeControlColorsLabelsCheckBoxes(Color.Transparent);

                this.BackColor = Color.White;
            }
            else if ((valueFromForm2 == "Medium Mode"))
            {
                ChangeControlsForeColor(this, Color.Black);

                ChangeControlsBackColor(this, Color.Gainsboro);

                ChangeControlColorsLabelsCheckBoxes(Color.Transparent);

                this.BackColor = Color.Gainsboro;
            }
            else if ((valueFromForm2 == "Custom Color"))
            {
                Color selectedBackColor = Properties.Settings.Default.CustomBackColor;
                Color contrastingForeColor = GetContrastingColor(selectedBackColor);

                ChangeControlsBackColor(this, selectedBackColor);
                ChangeControlsForeColor(this, contrastingForeColor);
                this.BackColor = selectedBackColor;
            }
        }
    }
}