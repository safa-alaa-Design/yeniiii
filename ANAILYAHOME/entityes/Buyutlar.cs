using ANAILYAHOME.Models;

namespace ANAILYAHOME.entityes
{
    public class Buyutlar
    {
        
            public int id { get; set; }
            public string Genişlik { get; set; }
            public string Yükseklik { get; set; }
            public string Derinlik { get; set; }
            public int UrunId { get; set; }
            public urunEntity urun { get; set; }

        
    }
}
