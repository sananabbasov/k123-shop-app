using System;
using System.Net;
using System.Net.Mail;
using K123ShopApp.Core.Configurations;

namespace K123ShopApp.Core.Utilities.MailHelper
{
    public class MailSender : IMailSender
    {
        public bool SendMail(string mailAddress, string message, bool bodyHtml)
        {

            var emailAddress = EmailConfiguration.Email;
            var emailPassword = EmailConfiguration.Password;
            string senderEmail = emailAddress;
            string senderPassword = emailPassword;

            //Create the SMTP client
            SmtpClient smtpClient = new SmtpClient(EmailConfiguration.Smtp, EmailConfiguration.Port);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            try
            {
                // Create the email message
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(senderEmail);
                mailMessage.To.Add(mailAddress);
                mailMessage.Subject = $"Message from - {EmailConfiguration.Email}";
                mailMessage.Body = $"<a href='{message}'>Tesdiq et</a>";
                // Specify that the body contains HTML
                mailMessage.IsBodyHtml = true;
                // Send the email
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email sent successfully.");
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
                return false;

            }
        }
    }
}

