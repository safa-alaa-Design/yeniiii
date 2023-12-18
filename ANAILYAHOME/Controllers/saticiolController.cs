using ANAILYAHOME.saticiol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ANAILYAHOME.Controllers
{
    public class ddf : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }

    public class saticiolController : Controller
    {
        [HttpGet]
        public IActionResult sendEmail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult sendEmail(saticiol.saticiol model)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(model.email);
            mail.To.Add(new MailAddress("safaalhassn@gmail.com"));
            mail.Subject = "hello";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            string body =
                "Kimlik:" +model.Kimlik +"<br>" +
                 "Adi:" + model.Adi + "<br>" +
                  "Soyadi:" + model.Soyadı + "<br>" +
                   "Email:" + model.email + "<br>" +
                    "Telefon:" + model.Telefon + "<br>" +
                     "Adres:" + model.saticiadres + "<br>" +
                      "Şirket Adi:" + model.ŞirketAdi + "<br>" +
                        "Şirket Adres:" + model.ŞirketAdres + "<br>" +
                          "Katagore:" + model.katagore + "<br>" +
                            "Şirket Hakkinda :" + model.sirketTanim + "<br>" ;
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
            ViewBag.Message = "mail has been send successfully";
            return View();
           
        }
    }
}
