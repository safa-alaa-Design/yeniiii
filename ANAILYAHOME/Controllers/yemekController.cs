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
    public class yemekController : Controller
    {

        private readonly AplicetionDbContext _db;
        private readonly IConfiguration _con;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public yemekController(AplicetionDbContext db, IConfiguration con, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _con = con;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult yemekoda()
        {

            List<YemekOdasi> itemsList = _db.yemek.Include(c => c.urun).ToList();

            return View(itemsList);
        }


        //upload


        /// /////////////////////////////////////upload

        public IActionResult uploadIndex(FotoEntity item, int urunId)
        {
            
                List<FotoEntity> foto = _db.foto.Include(x => x.urun).Where(d => d.UrunId == urunId).ToList();
                ViewBag.urunId = urunId;
                return View(foto);
           

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult uploadIndex(List<IFormFile> file, int urunId)
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


                fotoEntities.Add(new FotoEntity
                {
                    FileName = entitiy.FileName,
                    ContentType = entitiy.ContentType,
                    UrunId = urunId
                });
                if (entitiy.FileName != null)
                {
                    string folder = "uploads/";
                    folder += /*Guid.NewGuid().ToString()+"_"+*/ entitiy.FileName;
                    string servesfolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    using FileStream fileStream = new(servesfolder, FileMode.Create);
                    entitiy.CopyTo(fileStream);
                }

            }

            _db.AddRange(fotoEntities);
            _db.SaveChanges();
            return RedirectToAction("uploadIndex", new { urunId = urunId });
        }

        public ActionResult fotosil(int id, int urunId)
        {
            var sl = _db.foto.Find(id);
            _db.foto.Remove(sl);
            _db.SaveChanges();
            return RedirectToAction("uploadIndex", new { urunId = urunId });


        }

        /// /////////////////////////////////////uplod


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

            p.katagore = katagore.YemekOdası;
            var entity = new YemekOdasi
            {
                MasaTuru = p.yemek.MasaTuru,
                SandaliyeSayisi = p.yemek.SandaliyeSayisi,

                urun = new urunEntity()

            };

            _db.urun.Add(p);
            _db.SaveChanges();
            return RedirectToAction("yemekoda");
        }
        //GET
        public IActionResult Edit(int id)
        {
            urunEntity entity = _db.urun
           .Include(y => y.yemek)
           .Include(bu => bu.ListofBuyut)
           .Include(fi => fi.Listoffiyat)
           .ThenInclude(d => d.yemekfiyat)
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



            var yemek = _db.yemek.FirstOrDefault(i => i.UrunId == entity.id);
            if (yemek != null)
                _db.yemek.Remove(yemek);


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
            return RedirectToAction("yemekoda");
        }


        //GET
        public IActionResult Delete(int id)
        {

            urunEntity entity = _db.urun
               .Include(y => y.yemek)
               .Include(bu => bu.ListofBuyut)
               .Include(fi => fi.Listoffiyat)
               .ThenInclude(d => d.yemekfiyat)
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
            return RedirectToAction("Index");

        }


    }
}
