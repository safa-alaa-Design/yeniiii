using ANAILYAHOME.Models;

namespace ANAILYAHOME.entityes
{
    public class Degerler
    {
        public int id { get; set; }
        public int UrunId { get; set; }
        public urunEntity urun { get; set; }
        public int prodouctId { get; set; }
        public ProductDeger prodouct { get; set; }
    }

}
