using ANAILYAHOME.entityes;
using ANAILYAHOME.models;
using ANAILYAHOME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ANAILYAHOME.Controllers
{
    public class OturmaOdasiController : Controller
    {
        public OturmaOdasiController(AplicetionDbContext db, IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }

        private readonly IHostingEnvironment _host;
        private readonly AplicetionDbContext _db;

        public IActionResult Index()
        {

             IEnumerable<OturmaOdasi> itemsList = _db.oturma.Include(c => c.urun).ToList();
            return View(itemsList);
        }
            
        

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(oturmaEkleModels model)
        {
            //عند رفع قيمة فارغة يرجع الانبوت لفارغ
            if (ModelState.IsValid)
            {
                var entity = new OturmaOdasi
                {
                    YatakOlmak = model.YatakOlmak,

                    urun = new urunEntity
                    {
                        AdmenbanalId = 1,
                        katagore = katagore.OturmaOdası,
                        urunKod = model.urunKod,
                        tanım = model.tanım,
                        urunAdı = model.urunAdı,
                        sungurTipi = model.sungurTipi,
                        ahsapTipi = model.ahsapTipi,
                    }

                };

                _db.oturma.Add(entity);
                _db.SaveChanges();
                //رساله تمت اضافة المنتج عند اضافة المنتج
                TempData["successData"] = "Urun Eklendi";
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.oturma.FirstOrDefault(x=>x.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OturmaOdasi item)
        {
          
            if (ModelState.IsValid)
            {
                _db.oturma.Update(item);
                _db.SaveChanges();
                //رساله تم تعديل المنتج عند اضافة المنتج
                TempData["successData"] = "Urun güncellendi";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }


        //GET
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.oturma.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? id)
        {
            var item = _db.oturma.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _db.Remove(item);
            _db.SaveChanges();
            //رساله تم حذف المنتج عند اضافة المنتج
            TempData["successData"] = "Urun silindı";
            return RedirectToAction("Index");
        }

    }
}
