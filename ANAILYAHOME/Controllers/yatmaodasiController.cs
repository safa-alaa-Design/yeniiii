using ANAILYAHOME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ANAILYAHOME.entityes;
using ANAILYAHOME.Migrations;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;


namespace ANAILYAHOME.Controllers
{
    public class yatmaodasiController : Controller
    {
        private readonly AplicetionDbContext _db;
        private readonly IConfiguration _con;
        public yatmaodasiController(AplicetionDbContext db, IConfiguration con)
        {
            _db = db;
            _con = con;
        }

        public IActionResult yatmaodasi()
        {
            List<urunEntity> urun = _db.urun.Include(c => c.yatma).ToList();


            return View(urun);
        }
        public IActionResult Create()
        {
            urunEntity urun = new urunEntity();
            urun.ListofBuyut.Add(new Buyutlar() { id = 1 });
            urun.Listoffoto.Add(new FotoEntity() { id = 1 });
            urun.Listoffiyat.Add(new FiyatEntity() { id = 1 });
            return View("Create", urun);



        }
        [HttpPost]
        public IActionResult Create(urunEntity p)
        {
            var saticiid = Convert.ToInt32(User.Claims.FirstOrDefault(i=>i.Type == "SaticiId") );
            p.AdmenbanalId = saticiid;

            p.ListofBuyut.RemoveAll(n => n.IsDeleted == true);

            var entity = new YatmaOdasi
            {

                dulapKapiTipi = p.yatma.dulapKapiTipi,
                çekmeceliSayi = p.yatma.çekmeceliSayi,
                yatakTacRengi = p.yatma.yatakTacRengi,
                urun = new urunEntity(),
            };

            _db.urun.Add(p);
            _db.SaveChanges();
            return RedirectToAction("yatmaodasi");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            urunEntity entity = _db.urun
               .Include(y => y.yatma)
               .Include(bu => bu.ListofBuyut)
               .Include(fo => fo.Listoffoto)
               .Include(fi => fi.Listoffiyat)
               .ThenInclude(d => d.yatmafiyat)
               .Where(a => a.id == id).FirstOrDefault()!;
            return View(entity);




        }

        [HttpPost]

        public IActionResult Edit(urunEntity entity)
        {
            //entity.ListofBuyut = null;
            //entity.Listoffoto = null;
            //entity.Listoffiyat = null;
            entity.AdmenbanalId = 1;



            var yatma = _db.yatma.FirstOrDefault(i => i.UrunId == entity.id);
            if (yatma != null)
            _db.yatma.Remove(yatma);
          

            List<Buyutlar> buytDetail = _db.buyut.Where(d => d.UrunId == entity.id).ToList();
            if (buytDetail != null)
                _db.buyut.RemoveRange(buytDetail);
               
            List<FotoEntity> fotofDetail = _db.foto.Where(d => d.UrunId == entity.id).ToList();
            if (fotofDetail != null)
            _db.foto.RemoveRange(fotofDetail);
             

            List<FiyatEntity> fiyatDetail = _db.fiyat.Where(d => d.UrunId == entity.id).ToList();
            if (fiyatDetail != null)
           _db.fiyat.RemoveRange(fiyatDetail);


            entity.ListofBuyut.RemoveAll(n => n.IsDeleted == true);

            _db.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;

            _db.buyut.AddRange(entity.ListofBuyut);
            _db.foto.AddRange(entity.Listoffoto);
            _db.fiyat.AddRange(entity.Listoffiyat);
          

            _db.urun.Update(entity);
            _db.SaveChanges();
            return RedirectToAction("yatmaodasi");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            urunEntity entity = _db.urun
               .Include(y => y.yatma)
               .Include(bu => bu.ListofBuyut)
               .Include(fo => fo.Listoffoto)
               .Include(fi => fi.Listoffiyat)
               .ThenInclude(d => d.yatmafiyat)
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
            return RedirectToAction("yatmaodasi");

        }













        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





    }
}
