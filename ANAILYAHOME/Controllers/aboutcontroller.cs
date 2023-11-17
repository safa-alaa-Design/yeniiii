﻿using ANAILYAHOME.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace ANAILYAHOME.Controllers
{
    public class aboutcontroller : Controller
    {
        public IActionResult about()
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
