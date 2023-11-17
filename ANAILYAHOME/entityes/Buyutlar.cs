using ANAILYAHOME.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANAILYAHOME.entityes
{
    public class Buyutlar
    {
        
            public int id { get; set; }
             public string Ad {  get; set; }
            public string Genişlik { get; set; }
            public string Yükseklik { get; set; }
            public string Derinlik { get; set; }
            public int UrunId { get; set; }
            public urunEntity urun { get; set; }

            [NotMapped]
            public bool IsDeleted { get; set; } = false;
        
    }
}
