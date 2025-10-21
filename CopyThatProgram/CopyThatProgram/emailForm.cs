using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyThatProgram
{
    public partial class emailForm : Form
    {

        private mainForm main;
        public emailForm()
        {
            InitializeComponent();
            main = new mainForm();
        }

        private void exitPicBox_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void sendEmailButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Call the method in Form1 to get data
                var data = main.GetDataGridViewData();

                // Save data to a text file
                string filePath = Path.GetTempFileName();
                main.ExportDataToFile(filePath, data);

                // Sender's Gmail address and password (for authentication)
                string senderEmail = emailFromTextBox.Text;
                string senderPassword = emailAddressFromPassword.Text;

                // Recipient's email address
                string recipientEmail = emailAddressToTextBox.Text;

                // Mail message details
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                mail.Subject = emailSubjectTextBox.Text;
                mail.Body = emailBodyTextBox.Text;

                // Attach the file
                Attachment attachment = new Attachment(filePath);
                mail.Attachments.Add(attachment);

                // SMTP client details for Gmail
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                // Send the email
                smtpClient.Send(mail);

                MessageBox.Show("Email Sent Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Sending Email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ChangeControlsForeColor(Control control, Color newColor)
        {
            // Iterate through all controls in the form
            foreach (Control ctrl in control.Controls)
            {
                // Change the ForeColor of the control to white
                ctrl.ForeColor = newColor;

                // If the control has child controls, recursively call the method
                if (ctrl.HasChildren)
                {
                    ChangeControlsForeColor(ctrl, newColor);
                }
            }
        }

        private void ChangeControlsBackColor(Control control, Color newColor)
        {
            // Iterate through all controls in the form
            foreach (Control ctrl in control.Controls)
            {
                // Change the BackColor of the control to black
                ctrl.BackColor = newColor;

                // If the control has child controls, recursively call the method
                if (ctrl.HasChildren)
                {
                    ChangeControlsBackColor(ctrl, newColor);
                }
            }
        }

        private void ChangeLabelsForeColorBlack(Control control, Color newColor)
        {
            // Iterate through all controls in the form
            foreach (Control ctrl in control.Controls)
            {
                // Check if the control is a label
                if (ctrl is Label)
                {
                    // Change the ForeColor of the label to black
                    ((Label)ctrl).ForeColor = newColor;
                }

                // If the control has child controls, recursively call the method
                if (ctrl.HasChildren)
                {
                    ChangeLabelsForeColorBlack(ctrl, newColor);
                }
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {

        }

        private void EmailForm_Load(object sender, EventArgs e)
        {
            string valueFromForm2 = main.GetStringVariable();
            // MessageBox.Show($"Value from mainForm: {valueFromForm2}");

            if (valueFromForm2 == "Dark Mode")
            {
                ChangeControlsForeColor(this, Color.White);

                ChangeControlsBackColor(this, Color.Black);


                this.BackColor = Color.Black;
            }
            else
            {
                ChangeControlsForeColor(this, Color.Black);

                ChangeControlsBackColor(this, Color.White);

                this.BackColor = Color.White;
            }
        }
    }
}
