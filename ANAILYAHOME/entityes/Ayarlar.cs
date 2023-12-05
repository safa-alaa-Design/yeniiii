namespace ANAILYAHOME.Models
{
    public class TeslimSuresi
    {
        public int id { get; set; }
        public ulkeler ulkeler { get; set; }
        public int teslimsuresi { get; set; }

    }

    public class kumastipi
    {
        public int id { get; set; }
        public string kumasTipi { get; set; }

    }
    public class renkler
    {
        public int id { get; set; }
        public string renk { get; set; }

    }
    public class ayagitipi
    {
        public int id { get; set; }
        public string ayagiTipi { get; set; }

    }

}
