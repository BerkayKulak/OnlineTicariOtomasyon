using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        private Context c = new Context();
        public ActionResult Index()
        {
            // Carileri say
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            // ürünlerdeki stok sayısının toplamı
            var deger5 = c.Uruns.Sum(x=>x.Stok).ToString();
            ViewBag.d5 = deger5;

            //Kaç Çeşit Marka Var
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count();
            ViewBag.d6 = deger6;

            //Stok sayısı 20 nin altında olan ürün sayısı
            var deger7 = c.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;

            // max fiyatlı ürün
            var deger8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;



            return View();
        }
    }
}