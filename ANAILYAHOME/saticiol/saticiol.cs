using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ANAILYAHOME.saticiol
{
    public class saticiol
    {
        [Key]
        [Required]
        public string Kimlik { get; set; }
        [Required]
        public string Adi { get; set; }
        [Required]
        public string Soyadı { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string saticiadres { get; set; }
        [Required]
        public int Telefon { get; set; }
        [Required]
        public string ŞirketAdres { get; set; }
        [Required]
        public string ŞirketAdi { get; set; }
        [Required]
        public string katagore { get; set; }
        [Required]
        public string sirketTanim { get; set; }
        public string? file { get; set; }
    }

}
