using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Service
{
    public static class EmailHandler
    {
        public static void SendEmail(string to, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage("gokberozay@gmail.com", to, subject, message);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("gokberozay@gmail.com", "Gokber2021");

            smtpClient.Send(mailMessage);
        }
    }
}
