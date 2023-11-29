using ANAILYAHOME.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANAILYAHOME.entityes
{
    public class FotoEntity
    {
        [Key]
        public int id { get; set; }
        [NotMapped]
        public List<IFormFile> Files { get; set; }
     
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public string? StoredFileName {  get; set; }
        public int UrunId { get; set; }
        public urunEntity urun { get; set; }

      

    }
}
