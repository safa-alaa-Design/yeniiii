using ANAILYAHOME.saticiol;
using ANAILYAHOME.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Net.Mail;
namespace ANAILYAHOME.Controllers
{
    public class saticiolController : Controller
    {
        private readonly IEmailSender _emailSender;
        public saticiolController(IEmailSender emailsender)
        {
            _emailSender = emailsender;
        }
        [HttpGet]
        public IActionResult sendEmail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult sendEmail(saticiol.saticiol model)
        {
            string body =
                "Kimlik:" + model.Kimlik + "<br>" +
                 "Adi:" + model.Adi + "<br>" +
                  "Soyadi:" + model.Soyadı + "<br>" +
                   "Email:" + model.email + "<br>" +
                    "Telefon:" + model.Telefon + "<br>" +
                     "Adres:" + model.saticiadres + "<br>" +
                      "Şirket Adi:" + model.ŞirketAdi + "<br>" +
                        "Şirket Adres:" + model.ŞirketAdres + "<br>" +
                          "Katagore:" + model.katagore + "<br>" +
                            "Şirket Hakkinda :" + model.sirketTanim + "<br>";

            _emailSender.SendEmailAsync(model.email,model.Adi, body);
            return View();

        }
    }
}
