using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        private Context context = new Context();
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

        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = context.Uruns.ToList();
            sonuclar.ToList().ForEach(x=>xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y=>yvalue.Add(y.Stok));
            var grafik = new Chart(width: 500, height: 500).AddTitle("Stoklar")
                .AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }


    }
}