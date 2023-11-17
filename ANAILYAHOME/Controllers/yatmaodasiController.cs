using ANAILYAHOME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ANAILYAHOME.entityes;
using ANAILYAHOME.Migrations;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;


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
           
            
                p.ListofBuyut.RemoveAll(n => n.IsDeleted == true);


                p.AdmenbanalId = 1;
        
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
        




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }






        //private List<FiyatEntity> getulke() 
        //{
        //    List<FiyatEntity> ulkeker = _db.fiyat
        //        .OrderBy(n => n.ulkeler)
        //        .Select(n =>
        //        new FiyatEntity
        //        {
        //            ulkeler = n.ulkeler
        //        }).ToList();
        //    var selektulke = new List<FiyatEntity>()
        //    {

        //    };

        //    ulkeler.Insert(0, selektulke);
        //    return ulkeker;


        //}


    }
}
