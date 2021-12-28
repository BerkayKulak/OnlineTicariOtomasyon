﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Sınıflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Aciklama { get; set; }
        public string TarihZaman { get; set; }

    }
}