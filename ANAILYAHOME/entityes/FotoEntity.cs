﻿using ANAILYAHOME.Models;
using System.ComponentModel.DataAnnotations;

namespace ANAILYAHOME.entityes
{
    public class FotoEntity
    {
        [Key]
        public int id { get; set; }
        public string foto { get; set; }
        public int UrunId { get; set; }
        public urunEntity urun { get; set; }
    }
}