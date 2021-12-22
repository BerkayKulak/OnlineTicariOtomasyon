using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        private Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Carilers.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cariler cariler)
        {
            cariler.Durum = true;
            context.Carilers.Add(cariler);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cariler = context.Carilers.Find(id);
            cariler.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = context.Carilers.Find(id);
            return View("CariGetir", cari);
        }

        public ActionResult CariGuncelle(Cariler cariler)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = context.Carilers.Find(cariler.CariId);
            cari.CariAd = cariler.CariAd;
            cari.CariSoyad = cariler.CariSoyad;
            cari.CariSehir = cariler.CariSehir;
            cari.CariMail = cariler.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.CariId == id).ToList();
            var cari = context.Carilers.Where(x => x.CariId == id).Select(y => y.CariAd).FirstOrDefault();
            ViewBag.cari = cari;
            return View(degerler);
        }

    }
}