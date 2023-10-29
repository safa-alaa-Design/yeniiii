using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ANAILYAHOME.Models;

namespace ANAILYAHOME.Controllers
{
    public class sandalyeController : Controller
    {
        public IActionResult sandalya()
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
