using ANAILYAHOME.entityes;
using ANAILYAHOME.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANAILYAHOME.Models
{

    public enum ulkeler
    {
        Avrupa = 1,
        Turkiye = 2,
        İrak = 3,
        Saudiye = 4,
        lubnan = 5,
        Surye = 6,
        Libya = 7,
        Imarat = 8,
        Deger = 9,



    }
    public enum katagore
    {
        OturmaOdası = 1,
        YatmaOdası = 2,
        ÇocukOdası = 3,
        YemekOdası = 4,
        Değerİşyeler = 5,
        Tüm = 6

    }



    public class urunEntity
    {
        internal object urun;

        [Key]
        public int id { get; set; }
        public int urunKod { get; set; }
        public string urunAdı { get; set; }
        public string? tanım { get; set; }
        public string? ahsapTipi { get; set; }
        public string? sungurTipi { get; set; }
        public katagore katagore { get; set; }
        [ForeignKey("AmenbanalId")]
        public int AdmenbanalId { get; set; }
        public OturmaOdasi oturma { get; set; }
        public YatmaOdasi yatma { get; set; }
        public CocukOdasi cocuk { get; set; }
        public YemekOdasi yemek { get; set; }
        public Degerler deger { get; set; }

        public virtual List<Buyutlar> ListofBuyut { get; set; } = new List<Buyutlar>();
        public virtual List<FiyatEntity> Listoffiyat { get; set; } = new List<FiyatEntity>();
        public virtual List<FotoEntity> Listoffoto { get; set; } = new List<FotoEntity>();
        public AdmenbanalEntity Admenbanal { get; set; }
        public List<alışverişEntity> Listofalışveriş { get; set; } = new List<alışverişEntity>();   
    }





       


        
      

       





       
      
        
    



    



   


   

  
















   


}
