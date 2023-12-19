using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace ANAILYAHOME.Services

{
    public class EmailSender : IEmailSender
    {

        public async Task SendEmailAsync(string email, string subject, string body )
        {
            MailMessage mail = new MailMessage();
            mail.From=new MailAddress(email);
            mail.To.Add(new MailAddress("safaalhassn50000@gmail.com"));
            mail.Subject = "hello";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            mail.Body = body;

                SmtpClient SmtpClient = new SmtpClient();
                //SmtpClient.Port = 587;
                SmtpClient.Host = "smtp.gmail.com";
                //SmtpClient.EnableSsl = true;
                NetworkCredential Credentials = new NetworkCredential("safaalhassn50000@gmail.com", "QqBbSs1234567");
                SmtpClient.UseDefaultCredentials = true;
                SmtpClient.Credentials = Credentials;
                SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpClient.Send(mail);


        }

        
    }
    
}
