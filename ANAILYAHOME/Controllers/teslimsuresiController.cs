using ANAILYAHOME.entityes;
using ANAILYAHOME.Migrations;
using ANAILYAHOME.models;
using ANAILYAHOME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ANAILYAHOME.Controllers
{
    public class teslimsuresiController : Controller
    {

        private readonly AplicetionDbContext _db;

        public teslimsuresiController(AplicetionDbContext db)
        {
            _db = db;

        }
        public IActionResult teslimsuresi()
        {
            List<TeslimSuresi> itemsList = _db.TeslimSure.ToList();

            return View(itemsList);
        }



        public IActionResult Create()
        {

            return View();


        }

        [HttpPost]

        public IActionResult Create(TeslimSuresi p)
        {
            //عند رفع قيمة فارغة يرجع الانبوت لفارغ
            if (ModelState.IsValid)
            {
                var entity = new TeslimSuresi
                {
                    teslimsuresi = p.teslimsuresi,
                   ulkeler = p.ulkeler,
                };

                _db.TeslimSure.Add(entity);
                _db.SaveChanges();
                return RedirectToAction("teslimsuresi");
            }
            else
            {
                return View(p);
            }
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var item = _db.TeslimSure.FirstOrDefault(x => x.id == id);
            if (item == null)
            {
                return NotFound();
            }
            var model = new TeslimSuresi
            {
                teslimsuresi = item.teslimsuresi,
                ulkeler = item.ulkeler,

            };
            return View(model);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TeslimSuresi model)
        {


            if (ModelState.IsValid)
            {
                var entity = _db.TeslimSure.FirstOrDefault(x => x.id == model.id);
                entity.teslimsuresi = model.teslimsuresi;
                entity.ulkeler = model.ulkeler;


                _db.TeslimSure.Update(entity);
                _db.SaveChanges();
                return RedirectToAction("teslimsuresi");
            }
            else
            {
                return View(model);
            }
        }







        public ActionResult sil(int id)
        {
            var sl = _db.TeslimSure.Find(id);
            _db.TeslimSure.Remove(sl);
            _db.SaveChanges();
            return RedirectToAction("teslimsuresi");


        }

    }
}
