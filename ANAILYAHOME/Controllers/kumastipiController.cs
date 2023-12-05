using ANAILYAHOME.entityes;
using ANAILYAHOME.Migrations;
using ANAILYAHOME.models;
using ANAILYAHOME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ANAILYAHOME.Controllers
{
    public class kumastipiController : Controller
    {

        private readonly AplicetionDbContext _db;

        public kumastipiController(AplicetionDbContext db)
        {
            _db = db;

        }
        public IActionResult kumastipi()
        {
            List<kumastipi> itemsList = _db.kumas.ToList();

            return View(itemsList);
        }



        public IActionResult Create()
        {

            return View();


        }

        [HttpPost]

        public IActionResult Create(kumastipi p)
        {

            //عند رفع قيمة فارغة يرجع الانبوت لفارغ
            if (ModelState.IsValid)
            {
                var entity = new kumastipi
                {
                    kumasTipi = p.kumasTipi,
                };

                _db.kumas.Add(entity);
                _db.SaveChanges();
                return RedirectToAction("kumastipi");
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult kumassil(int id)
        {
            var sl = _db.kumas.Find(id);
            _db.kumas.Remove(sl);
            _db.SaveChanges();
            return RedirectToAction("kumastipi");


        }

    }
}
