using System.ComponentModel.DataAnnotations;

namespace ANAILYAHOME.entityes
{
    public class ProductDeger
    {
        [Key]
        public int id { get; set; }
        public string katagore { get; set; }
        public List<Degerler> Listofdegerler { get; set; }
    }
}
