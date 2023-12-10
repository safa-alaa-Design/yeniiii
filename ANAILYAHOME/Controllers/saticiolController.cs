using ANAILYAHOME.saticiol;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace ANAILYAHOME.Controllers
{
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

            using(SmtpClient SmtpClient = new SmtpClient())
            {
                SmtpClient.Port = 587;
                SmtpClient.Host = "smtp.gmail.com";
                SmtpClient.EnableSsl = true;
                SmtpClient.UseDefaultCredentials = false;
                SmtpClient.Credentials = new NetworkCredential("safaalhassn@gmail.com", "QqBbSs1234567");
                SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                if (SmtpClient!= null)
                    SmtpClient.Send(mail);

            }
            return RedirectToAction("sendEmail");
        }
    }
}
