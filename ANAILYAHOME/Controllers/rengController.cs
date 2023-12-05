using ANAILYAHOME.entityes;
using ANAILYAHOME.Migrations;
using ANAILYAHOME.models;
using ANAILYAHOME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ANAILYAHOME.Controllers
{
    public class rengController : Controller
    {

        private readonly AplicetionDbContext _db;
       
        public rengController(AplicetionDbContext db)
        {
            _db = db;
           
        }
        public IActionResult reng()
        {
            List<renkler> itemsList = _db.renk.ToList();

            return View(itemsList);
        }



        public IActionResult Create()
        {
            
            return View();


        }

        [HttpPost]

        public IActionResult Create(renkler p)
        {

            //عند رفع قيمة فارغة يرجع الانبوت لفارغ
            if (ModelState.IsValid)
            {
                var entity = new renkler
                {
                    renk = p.renk,
                };

                _db.renk.Add(entity);
                _db.SaveChanges();
                return RedirectToAction("reng");
            }
            else
            {
                return View(p);
            }
        }

            public ActionResult rengsil(int id)
            {
                var sl = _db.renk.Find(id);
                _db.renk.Remove(sl);
                _db.SaveChanges();
                return RedirectToAction("reng");


            }

    }
}
