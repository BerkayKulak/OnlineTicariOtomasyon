using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Sınıflar
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }
        public string DepartmanAd { get; set; }
    }
}