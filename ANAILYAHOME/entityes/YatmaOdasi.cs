using ANAILYAHOME.Models;

namespace ANAILYAHOME.entityes
{
    public class YatmaOdasi
    {
        public int id { get; set; }
        public string? yatakTacRengi { get; set; }
        public int? çekmeceliSayi { get; set; }
        public string? dulapKapiTipi { get; set; }
        public int UrunId { get; set; }
        public urunEntity urun { get; set; }

    }
}
