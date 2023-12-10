using System.ComponentModel.DataAnnotations;
using ANAILYAHOME.Models;
using Microsoft.AspNetCore.Identity;


namespace ANAILYAHOME.Models
{
    public class AliciEntity
    {


        [Key]
        public int id { get; set; }
        public string ad { get; set; }
        public string soyadi { get; set; }
        public string Pasword { get; set; }
        public string adres { get; set; }
        public string email { get; set; }
        public string Tc { get; set; }
        public string telefon { get; set; }
        public ulkeler ulkeler { get; set; }
        public int userId { get; set; }
        public AplicationUser AspNetUsers { get; set; }

        public List<alışverişEntity> Listofalışveriş { get; set; }
    }


    public class alışverişEntity
    {
        public int id { get; set; }
        public int satsTarih { get; set; }
        public int urunSaysi { get; set; }
        public int urunTipi { get; set; }
        public int ToplamFiyat { get; set; }
        public AliciEntity Alici { get; set; }
        public urunEntity urun { get; set; }
        public int AliciId { get; set; }
        public int urunId { get; set; }
       
    }






    public class BayiKategori
    {
        [Key]
        public int id { get; set; }
        public int Bayiid { get; set; }
        public AdmenbanalEntity Admenbanal { get; set; }
        public katagore katagore { get; set; }

    }



    public class AdmenbanalEntity
    {

        [Key]
        public int id { get; set; }
        public string Kimlik { get; set; }
        public string Adi { get; set; }
        public string Soyadı { get; set; }
        public string email { get; set; }
        public string saticiadres { get; set; }
        public int Telefon { get; set; }
        public string ŞirketAdres { get; set; }
        public string ŞirketAdi { get; set; }
        public string katagore { get; set; }
        public string sirketTanim { get; set; }
        public string? file { get; set; }
        public int userId { get; set; }
        public AplicationUser AspNetUsers { get; set; }
        public List<urunEntity> Listofurun { get; set; }
        public List<BayiKategori> BayiKategorilist { get; set; }

    }

    public class AplicationUser : IdentityUser<int>

    {
        [Required, MaxLength(100)]
        public string Adi { get; set; }

        [Required, MaxLength(100)]
        public string Soyadi { get; set; }
        public ulkeler ulkeler { get; set; }
        public AliciEntity Alici { get; set; }
        public AdmenbanalEntity Admenbanal { get; set; }
    }
}


 