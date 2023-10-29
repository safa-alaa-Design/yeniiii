using ANAILYAHOME.Models;

namespace ANAILYAHOME.entityes
{
    public class YemekOdasi
    {
        public int id { get; set; }
        public string? MasaTuru { get; set; }
        public int? SandaliyeSayisi { get; set; }
        public int UrunId { get; set; }
        public urunEntity urun { get; set; }

    }
}
