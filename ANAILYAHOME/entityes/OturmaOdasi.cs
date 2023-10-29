using ANAILYAHOME.Models;

namespace ANAILYAHOME.entityes
{
   

    public class OturmaOdasi
    {
        internal object otorma;
        public int id { get; set; }
        public Boolean? YatakOlmak { get; set; }
        public int UrunId { get; set; }
        public urunEntity urun { get; set; }

    }
}
