using ANAILYAHOME.entityes;
using ANAILYAHOME.Migrations;
using ANAILYAHOME.models;
using ANAILYAHOME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ANAILYAHOME.Controllers
{
    public class ayagitipiController : Controller
    {

        private readonly AplicetionDbContext _db;

        public ayagitipiController(AplicetionDbContext db)
        {
            _db = db;

        }
        public IActionResult ayagtipi()
        {
            List<ayagitipi> itemsList = _db.ayak.ToList();

            return View(itemsList);
        }



        public IActionResult Create()
        {

            return View();


        }

        [HttpPost]

        public IActionResult Create(ayagitipi p)
        {

            //عند رفع قيمة فارغة يرجع الانبوت لفارغ
            if (ModelState.IsValid)
            {
                var entity = new ayagitipi
                {
                    ayagiTipi = p.ayagiTipi,
                };

                _db.ayak.Add(entity);
                _db.SaveChanges();
                return RedirectToAction("ayagtipi");
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult ayagtipisil(int id)
        {
            var sl = _db.ayak.Find(id);
            _db.ayak.Remove(sl);
            _db.SaveChanges();
            return RedirectToAction("ayagtipi");


        }

    }
}
