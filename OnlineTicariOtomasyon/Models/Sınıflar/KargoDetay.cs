using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Sınıflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Aciklama { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TakipKodu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Personel{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Alici{ get; set; }
        public DateTime Tarih{ get; set; }

        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }

    }
}