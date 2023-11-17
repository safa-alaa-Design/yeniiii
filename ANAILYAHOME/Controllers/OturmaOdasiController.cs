using ANAILYAHOME.entityes;
using ANAILYAHOME.Migrations;
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

            List<urunEntity> itemsList = _db.urun.Include(c => c.oturma).ToList();
          
            return View(itemsList);
        }



        public IActionResult New()
        {
            //urunEntity urunlar = new urunEntity();
            //urunlar.ListofBuyut.Add(new Buyutlar() { id = 1 });
            //urunlar.ListofBuyut.Add(new Buyutlar() { id = 2  });
            //urunlar.ListofBuyut.Add(new Buyutlar() { id = 3 });
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

            var item = _db.oturma.Include(i => i.urun).FirstOrDefault(x => x.id == id);
            if (item == null)
            {
                return NotFound();
            }
            var model = new oturmaEkleModels
            {
                urunKod = item.urun.urunKod,
                tanım = item.urun.tanım,
                urunAdı = item.urun.urunAdı,
                sungurTipi = item.urun.sungurTipi,
                ahsapTipi = item.urun.ahsapTipi,

            };
            return View(model);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(oturmaEkleModels model)
        {


            if (ModelState.IsValid)
            {
                var entity = _db.oturma.Include(i => i.urun).FirstOrDefault(x => x.id == model.id);


                entity.YatakOlmak = model.YatakOlmak;
                entity.urun.urunAdı = model.urunAdı;
                entity.urun.urunKod = model.urunKod;
                entity.urun.tanım = model.tanım;
                entity.urun.sungurTipi = model.sungurTipi;
                entity.urun.ahsapTipi = model.ahsapTipi;


                _db.oturma.Update(entity);
                _db.SaveChanges();
                //رساله تم تعديل المنتج عند اضافة المنتج
                TempData["successData"] = "Urun güncellendi";
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }


        //GET
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.oturma.Include(i => i.urun).FirstOrDefault(x => x.id == id);
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
            var item = _db.urun.FirstOrDefault(i => i.oturma.id == id);

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
