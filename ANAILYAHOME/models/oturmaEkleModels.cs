﻿using System.ComponentModel.DataAnnotations;
using ANAILYAHOME.entityes;

namespace ANAILYAHOME.models
{
    public class oturmaEkleModels
    {
        [Key]
        public int id { get; set; }
        public int urunKod { get; set; }
        public string urunAdı { get; set; }
        public string tanım { get; set; }
        public string? sungurTipi { get; set; }
        public string? ahsapTipi { get; set; }
        public Boolean? YatakOlmak { get; set; }
        public string Genişlik { get; set; }
        public string Yükseklik { get; set; }
        public string Derinlik { get; set; }
        //public List<BoyutModels> boyutModels { get; set;}


    }
}
