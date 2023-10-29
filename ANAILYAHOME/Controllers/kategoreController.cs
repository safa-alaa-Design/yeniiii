//using ANAILYAHOME.entityes;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Authorization.Infrastructure;
//using ANAILYAHOME.models;
//using ANAILYAHOME.Repository.Base;
//using Microsoft.AspNetCore.Mvc;
//using ANAILYAHOME.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;
//namespace ANAILYAHOME.Controllers
//{
    //public class kategoreController : Controller
    //{
    //    public otormaodasiController(IRepository<urunEntity> repository)
    //    {
    //        _repository = repository;
    //    }
    //    AplicetionDbContext c = new AplicetionDbContext();


    //    private IRepository<urunEntity> _repository;

        //public IActionResult Index() 
        //{
        //    return View(_repository.FindAll());
        //}

        //public async Task<IActionResult> Index()
        //{
        //    var oneCat = _repository.selectOne(x => x.urunAdı == "drfgjhj");
        //    var allCat = await _repository.FindAllAsync("oturma");

        //    return View(allCat);
        //}

        ////GET
        //public IActionResult New()
        //{

        //    return View();
        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult New(oturmaEkleModels model)
        //{
        //    var entity = new OturmaOdasi
        //    {
        //        urun = new urunEntity
        //        {
        //            AdmenbanalId = 1,
        //            katagore = katagore.OturmaOdası,
        //            urunKod = model.urunKod,
        //            tanım = model.tanım,
        //            urunAdı = model.urunAdı,
        //            sungurTipi = model.sungurTipi,
        //            ahsapTipi = model.ahsapTipi,
        //        }

        //    };

        //    c.oturma.Add(entity);
        //    c.SaveChanges();
        //    return RedirectToAction("Index");
        //}



        //        //GET
        //        public IActionResult Edit(int? Id)
        //        {
        //            if (Id == null || Id == 0)
        //            {
        //                return NotFound();
        //            }
        //            var item = _db.Items.Find(Id);
        //            if (item == null)
        //            {
        //                return NotFound();
        //            }
        //            createSelectList(item.CategoryId);
        //            return View(item);
        //        }

        //        //POST
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public IActionResult Edit(Item item)
        //        {
        //            if (item.Name == "100")
        //            {
        //                ModelState.AddModelError("Name", "Name can't equal 100");
        //            }
        //            if (ModelState.IsValid)
        //            {
        //                _db.Items.Update(item);
        //                _db.SaveChanges();
        //                TempData["successData"] = "Item has been updated successfully";
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                return View(item);
        //            }
        //        }

        //        //GET
        //        public IActionResult Delete(int? Id)
        //        {
        //            if (Id == null || Id == 0)
        //            {
        //                return NotFound();
        //            }
        //            var item = _db.Items.Find(Id);
        //            if (item == null)
        //            {
        //                return NotFound();
        //            }
        //            createSelectList(item.CategoryId);
        //            return View(item);
        //        }

        //        //POST
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public IActionResult DeleteItem(int? Id)
        //        {
        //            var item = _db.Items.Find(Id);
        //            if (item == null)
        //            {
        //                return NotFound();
        //            }
        //            _db.Remove(item);
        //            _db.SaveChanges();
        //            TempData["successData"] = "Item has been deleted successfully";
        //            return RedirectToAction("Index");
        //        }
    //}

















































//[Authorize(Roles = clsRol.roleAdmin)]

//public class otormaodasiController : Controller
//{
//    //لاضافة غرفة قعدة بالادمن بانل

//    AplicetionDbContext c = new AplicetionDbContext();
//    public ActionResult oturmaListesi()
//    {
//        var deger = c.oturma.Include(i=>i.urun).ToList();
//        return View(deger);
//    }

//    [HttpGet]
//    public ActionResult yeniOturma()
//    {
//        return View();
//    }
//    [HttpPost]
//    public ActionResult yeniOturma(oturmaEkleModels model)
//    {
//        var entity = new OturmaOdasi
//        {
//            YatakOlmak = model.YatakOlmak,
//            urun = new urunEntity
//            {

//                AdmenbanalId = 1,
//                katagore = katagore.OturmaOdası,
//                urunKod = model.urunKod,
//                tanım = model.tanım,
//                urunAdı = model.urunAdı,
//                sungurTipi = model.sungurTipi,
//                ahsapTipi = model.ahsapTipi,

//            }

//        };

//        c.oturma.Add(entity);
//        c.SaveChanges();
//        return RedirectToAction("oturmaListesi");
//    }



//    public ActionResult oturmagetir(int id)
//    {  
//        var ag = c.oturma.Find(id);

//        return View("oturmagetir", ag);

//    }

//    //غلط بسبب الاعمدة بالاورون
//    public ActionResult oturmaguncele(oturmaEkleModels model)
//    {
//        var ag = c.oturma.Find(model.id);
//        ag.urun.urunAdı = model.urunAdı;
//        ag.urun.urunKod = model.urunKod;
//        ag.urun.ahsapTipi = model.ahsapTipi;
//        ag.urun.sungurTipi = model.sungurTipi;
//        ag.urun.tanım = model.tanım;


//        c.SaveChanges();
//        return RedirectToAction("oturmaListesi");
//    }


//    public ActionResult oturmasil(int id)
//    {
//        var sl = c.oturma.Find(id);
//        c.oturma.Remove(sl);
//        c.SaveChanges();
//        return RedirectToAction("oturmaListesi");


//    }

//}

