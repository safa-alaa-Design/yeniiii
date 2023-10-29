using ANAILYAHOME.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ANAILYAHOME.entityes;
using Microsoft.AspNetCore.Authorization;

namespace ANAILYAHOME.Controllers
{
    [Authorize(Roles =clsRol.roleAdmin)]
    public class AdmenController : Controller
    {
        AplicetionDbContext c = new AplicetionDbContext();

    

        //لاضافة صور  بالادمن بانل


        public ActionResult fotograf()
        {
            var deger = c.foto.Include(i=>i.urun).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult yeniFotograf()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniFotograf(FotoEntity p)
        {
            c.foto.Add(p);
            c.SaveChanges();
            return RedirectToAction("fotograf");
        }






        public ActionResult fotografgetir(int id)
        {
            var ag = c.foto.Find(id);

            return View("fotografgetir", ag);
        }


        public ActionResult fotografguncele(FotoEntity p)
        {
            var ag = c.foto.Find(p.id);
            ag.foto = p.foto;

            c.SaveChanges();
            return RedirectToAction("fotograf");
        }




        public ActionResult fotografsil(int id)
        {
            var sl = c.foto.Find(id);
            c.foto.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("fotograf");


        }




        //لاضافة المقاسات  بالادمن بانل


        public ActionResult boyutler()
        {
            var deger = c.buyut.Include(i => i.urun).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult yeniBoyut()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniBoyut(Buyutlar p)
        {
            c.buyut.Add(p);
            c.SaveChanges();
            return RedirectToAction("boyutler");
        }



        public ActionResult boyutgetir(int id)
        {
            var ag = c.buyut.Find(id);

            return View("boyutgetir", ag);
        }


        public ActionResult boyutguncele(Buyutlar p)
        {
            var ag = c.buyut.Find(p.id);
            ag.Genişlik = p.Genişlik;
            ag.Yükseklik = p.Yükseklik;
            ag.Derinlik = p.Derinlik;

            c.SaveChanges();
            return RedirectToAction("boyutler");
        }
        public ActionResult boyutsil(int id)
        {
            var sl = c.buyut.Find(id);
            c.buyut.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("boyutler");


        }






        //لاضافة الاسعار غرف القعده بالادمن بانل


        public ActionResult fiyat()
        {
            var deger = c.fiyat.Include(i => i.urun).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult yeniFiyat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniFiyat(FiyatEntity p)
        {
            c.fiyat.Add(p);
            c.SaveChanges();
            return RedirectToAction("fiyat");
        }


        public ActionResult fiyatgetir(int id)
        {
            var ag = c.fiyat.Find(id);

            return View("fiyatgetir", ag);
        }


        public ActionResult fiyatguncele(FiyatEntity p)
        {
            var ag = c.fiyat.Find(p.id);

            ag.Anafiyat = p.Anafiyat;
            ag.ulkeler = p.ulkeler;
            c.SaveChanges();
            return RedirectToAction("fiyat");
        }


        public ActionResult fiyatsil(int id)
        {
            var sl = c.fiyat.Find(id);
            c.fiyat.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("fiyat");


        }





        public ActionResult oturmafiyat()
        {
            var deger = c.oturmafiyat.Include(i=>i.fiyat).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult yenioturmaFiyat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenioturmaFiyat(oturmafiyatler p)
        {
            c.oturmafiyat.Add(p);
            c.SaveChanges();
            return RedirectToAction("oturmafiyat");
        }






        public ActionResult oturmafiyatgetir(int id)
        {
            var ag = c.oturmafiyat.Find(id);

            return View("oturmafiyatgetir", ag);
        }


        public ActionResult oturmafiyatguncele(oturmafiyatler p)
        {
            var ag = c.oturmafiyat.Find(p.id);
           
            ag.uclukultuk = p.uclukultuk;
            ag.ikilikultuk = p.ikilikultuk;
            ag.pejeri = p.pejeri;
            c.SaveChanges();
            return RedirectToAction("oturmafiyat");
        }

    
        public ActionResult oturmafiyatsil(int id)
        {
            var sl = c.oturmafiyat.Find(id);
            c.oturmafiyat.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("oturmafiyat");


        }




        //لاضافة الاسعار غرف النوم  بالادمن بانل


        public ActionResult yatmafiyat()
        {
            var deger = c.yatmafiyat.Include(i => i.fiyat).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult yeniyatmaFiyat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniyatmaFiyat(yatmafiyatler p)
        {
            c.yatmafiyat.Add(p);
            c.SaveChanges();
            return RedirectToAction("yatmafiyat");
        }



        public ActionResult yatmafiyatgetir(int id)
        {
            var ag = c.yatmafiyat.Find(id);

            return View("yatmafiyatgetir", ag);
        }


        public ActionResult yatmafiyatguncele(yatmafiyatler p)
        {
            var ag = c.yatmafiyat.Find(p.id);

            ag.Aynafiyat = p.Aynafiyat;
            ag.sanduk = p.sanduk;
            ag.yidilik = p.yidilik;
            ag.boffiyat = p.boffiyat;
            ag.anbarli = p.anbarli;
            ag.konsol = p.konsol;
            ag.yatakçekmeceli = p.yatakçekmeceli;
            ag.yataş = p.yataş;
            



            c.SaveChanges();
            return RedirectToAction("yatmafiyat");
        }

        public ActionResult yatmafiyatsil(int id)
        {
            var sl = c.yatmafiyat.Find(id);
            c.yatmafiyat.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("yatmafiyat");


        }



        //لاضافة الاسعار غرف النوم الاطفال بالادمن بانل


        public ActionResult cocukfiyat()
        {
            var deger = c.cocukfiyat.Include(i => i.fiyat).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult yenicocukFiyat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenicocukFiyat(cocukfiyatler p)
        {
            c.cocukfiyat.Add(p);
            c.SaveChanges();
            return RedirectToAction("cocukfiyat");
        }



        public ActionResult cocukfiyatgetir(int id)
        {
            var ag = c.cocukfiyat.Find(id);

            return View("cocukfiyatgetir", ag);
        }


        public ActionResult cocukfiyatguncele(cocukfiyatler p)
        {
            var ag = c.cocukfiyat.Find(p.id);
            ag.sandaliye = p.sandaliye;
            ag.raflar = p.raflar;
            ag.yataş = p.yataş;
            ag.calismamasasi = p.calismamasasi;
            ag.kutuphane = p.kutuphane;


            c.SaveChanges();
            return RedirectToAction("cocukfiyat");
        }


        public ActionResult cocukfiyatsil(int id)
        {
            var sl = c.cocukfiyat.Find(id);
            c.cocukfiyat.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("cocukfiyat");


        }


            //لاضافة الاسعار غرف  السفرة بالادمن بانل


            public ActionResult yemekfiyat()
        {
            var deger = c.yemekfiyat.Include(i => i.fiyat).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult yeniyemekFiyat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniyemekFiyat(yemekfiyatler p)
        {
            c.yemekfiyat.Add(p);
            c.SaveChanges();
            return RedirectToAction("yemekfiyat");
        }



        public ActionResult yemekfiyatgetir(int id)
        {
            var ag = c.yemekfiyat.Find(id);

            return View("yemekfiyatgetir", ag);
        }


        public ActionResult yemekfiyatguncele(yemekfiyatler p)
        {
            var ag = c.yemekfiyat.Find(p.id);
          
            ag.sandaliye = p.sandaliye;


            c.SaveChanges();
            return RedirectToAction("yemekfiyat");
        }




        public ActionResult yemekfiyatsil(int id)
        {
            var sl = c.yemekfiyat.Find(id);
            c.yemekfiyat.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("yemekfiyat");


        }






        //لاضافة الاسعار باقي المنتجات   بالادمن بانل


        //public ActionResult degerfiyat()
        //{
        //    var deger = c.fiyat.Include(i => i.urun).ToList();
        //    return View(deger);
        //}

        //[HttpGet]
        //public ActionResult yenidegerFiyat()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult yenidegerFiyat(fiyatEntity p)
        //{
        //    c.fiyat.Add(p);
        //    c.SaveChanges();
        //    return RedirectToAction("degerfiyat");
        //}



        //public ActionResult degerfiyatgetir(int id)
        //{
        //    var ag = c.fiyat.Find(id);

        //    return View("degerfiyatgetir", ag);
        //}


        //public ActionResult degerfiyatguncele(fiyatEntity p)
        //{
        //    var ag = c.fiyat.Find(p.id);
        //    ag.Anafiyat = p.Anafiyat;
        //    ag.ulkeler = p.ulkeler;
           
        //    c.SaveChanges();
        //    return RedirectToAction("degerfiyat");
        //}


















    }
}



