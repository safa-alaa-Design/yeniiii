using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ANAILYAHOME.Models;

namespace ANAILYAHOME.Controllers
{
    public class shopcontroller : Controller
    {
        public IActionResult shop()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
