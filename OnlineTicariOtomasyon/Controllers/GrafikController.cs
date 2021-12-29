using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler",
                xValue: new string[] {"Beyaz Eşya", "Telefon", "Küçük Ev Aleti"}, yValues: new int[] {85, 66, 98}).Write();
            return File(grafikciz.ToWebImage().GetBytes(),"image/jpeg");
        }
    }
}