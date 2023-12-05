﻿using ANAILYAHOME.entityes;
using ANAILYAHOME.Migrations;
using ANAILYAHOME.models;
using ANAILYAHOME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ANAILYAHOME.Controllers
{
    public class CocukOdasiController : Controller
    {

        private readonly AplicetionDbContext _db;
        private readonly IConfiguration _con;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CocukOdasiController(AplicetionDbContext db, IConfiguration con, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _con = con;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult cocukodasi()
        {

            List<CocukOdasi> itemsList = _db.cocuk.Include(c => c.urun).ToList();

            return View(itemsList);
        }


        //upload

        public IActionResult Upload(int urunId)
        {

            ViewBag.urunId = urunId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upload(List<IFormFile> file, int urunId)
        {
            //var fakeFileName = Path.GetRandomFileName();
            //    var entity = new FotoEntity
            //    {
            //        UrunId = urunId,
            //        FileName = file.FileName,
            //        ContentType = file.ContentType,
            //        StoredFileName = fakeFileName,

            //    };
            List<FotoEntity> fotoEntities = new();
            foreach (var entitiy in file)
            {
                var fakeFileName = Path.GetRandomFileName();
                fotoEntities.Add(new FotoEntity
                {
                    FileName = entitiy.FileName,
                    ContentType = entitiy.ContentType,
                    StoredFileName = fakeFileName,
                    UrunId = urunId
                });
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fakeFileName);
                using FileStream fileStream = new(path, FileMode.Create);
                entitiy.CopyTo(fileStream);

            }

            _db.AddRange(fotoEntities);
            _db.SaveChanges();
            return RedirectToAction("cocukodasi");
        }


        public IActionResult Create()
        {
            urunEntity urun = new urunEntity();
            urun.ListofBuyut.Add(new Buyutlar() { id = 1 });
            urun.Listoffiyat.Add(new FiyatEntity() { id = 1 });
            return View("Create", urun);


        }

        [HttpPost]

        public IActionResult Create(urunEntity p)
        {
            var saticiid = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypesadmin.SaticiId).Select(c => c.Value).SingleOrDefault());
            p.AdmenbanalId = 1;

            p.ListofBuyut.RemoveAll(n => n.IsDeleted == true);
            p.Listoffiyat.RemoveAll(n => n.IsHiddin == true);

            p.katagore = katagore.ÇocukOdası;
            var entity = new CocukOdasi
            {
                çekmeceliSayi = p.cocuk.çekmeceliSayi,
                yatakTacRengi = p.cocuk.yatakTacRengi,
                dulapKapiTipi = p.cocuk.dulapKapiTipi,

                urun = new urunEntity()

            };

            _db.urun.Add(p);
            _db.SaveChanges();
            return RedirectToAction("cocukodasi");
        }
        //GET
        public IActionResult Edit(int id)
        {
            urunEntity entity = _db.urun
           .Include(y => y.cocuk)
           .Include(bu => bu.ListofBuyut)
           .Include(fi => fi.Listoffiyat)
           .ThenInclude(d => d.cocukfiyat)
           .Where(a => a.id == id).FirstOrDefault()!;
            return View(entity);




        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(urunEntity entity)
        {
            //entity.ListofBuyut = null;
            //entity.Listoffoto = null;
            //entity.Listoffiyat = null;
            entity.AdmenbanalId = 1;



            var cocuk = _db.cocuk.FirstOrDefault(i => i.UrunId == entity.id);
            if (cocuk != null)
                _db.cocuk.Remove(cocuk);


            List<Buyutlar> buytDetail = _db.buyut.Where(d => d.UrunId == entity.id).ToList();
            if (buytDetail != null)
                _db.buyut.RemoveRange(buytDetail);

            List<FiyatEntity> fiyatDetail = _db.fiyat.Where(d => d.UrunId == entity.id).ToList();
            if (fiyatDetail != null)
                _db.fiyat.RemoveRange(fiyatDetail);


            entity.ListofBuyut.RemoveAll(n => n.IsDeleted == true);
            entity.Listoffiyat.RemoveAll(n => n.IsHiddin == true);

            _db.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;

            _db.buyut.AddRange(entity.ListofBuyut);
            _db.fiyat.AddRange(entity.Listoffiyat);


            _db.urun.Update(entity);
            _db.SaveChanges();
            return RedirectToAction("cocukodasi");
        }


        //GET
        public IActionResult Delete(int id)
        {

            urunEntity entity = _db.urun
               .Include(y => y.cocuk)
               .Include(bu => bu.ListofBuyut)
               .Include(fi => fi.Listoffiyat)
               .ThenInclude(d => d.cocukfiyat)
               .Where(a => a.id == id).FirstOrDefault()!;
            return View(entity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]


        public IActionResult Delete(urunEntity model)
        {
            _db.Attach(model);
            _db.Entry(model).State = EntityState.Deleted;

            _db.SaveChanges();
            return RedirectToAction("cocukodasi");

        }


    }
}
