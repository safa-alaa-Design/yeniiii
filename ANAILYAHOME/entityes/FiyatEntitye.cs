using ANAILYAHOME.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANAILYAHOME.entityes
{
    public class FiyatEntity
    {
        [Key]
        public int id { get; set; }
        public decimal Anafiyat { get; set; }
        public ulkeler ulkeler { get; set; }
        public int UrunId { get; set; }
        public urunEntity urun { get; set; }
        public oturmafiyatler oturmafiyat { get; set; }
        public yatmafiyatler yatmafiyat { get; set; }
        public cocukfiyatler cocukfiyat { get; set; }
        public yemekfiyatler yemekfiyat { get; set; }

        [NotMapped]
        public bool IsHiddin { get; set; } = false;

    }


    //اسعار غرف 
    public class oturmafiyatler
    {
        [Key]
        public int id { get; set; }
        public decimal? ikilikultuk { get; set; }
        public decimal? uclukultuk { get; set; }
        public decimal? pejeri { get; set; }
        public decimal? ortaSehba { get; set; }
        public decimal? ucluSehba { get; set; }
        public int fiyatId { get; set; }
        public FiyatEntity fiyat { get; set; }

    }
    public class yatmafiyatler
    {
        [Key]
        public int id { get; set; }
        public decimal? Aynafiyat { get; set; }
        public decimal? boffiyat { get; set; }
        public decimal? yidilik { get; set; }
        public decimal? sanduk { get; set; }
        public decimal? sandaliye { get; set; }
        public decimal? konsol { get; set; }
        public decimal? anbarli { get; set; }
        public decimal? yataş { get; set; }
        public decimal? yatakçekmeceli { get; set; }
        public int fiyatId { get; set; }
        public FiyatEntity fiyat { get; set; }

    }

    public class cocukfiyatler
    {
        [Key]
        public int id { get; set; }
        public decimal? kutuphane { get; set; }
        public decimal? calismamasasi { get; set; }
        public decimal? yataş { get; set; }
        public decimal? raflar { get; set; }
        public decimal? sandaliye { get; set; }
        public int fiyatId { get; set; }
        public FiyatEntity fiyat { get; set; }

    }



    public class yemekfiyatler
    {
        [Key]
        public int id { get; set; }
        public decimal? sandaliye { get; set; }
        public int fiyatId { get; set; }
        public FiyatEntity fiyat { get; set; }
    }
}
