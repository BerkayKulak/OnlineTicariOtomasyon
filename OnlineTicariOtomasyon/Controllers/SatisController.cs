using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        private Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in context.Uruns.ToList()
                select new SelectListItem()
                {
                    Text = x.UrunAd,
                    Value = x.UrunId.ToString()
                }).ToList();

            List<SelectListItem> deger2 = (from x in context.Carilers.ToList()
                select new SelectListItem()
                {
                    Text = x.CariAd,
                    Value = x.CariId.ToString()
                }).ToList();

            List<SelectListItem> deger3 = (from x in context.Personels.ToList()
                select new SelectListItem()
                {
                    Text = x.PersonelAd,
                    Value = x.PersonelId.ToString()
                }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satisHareket)
        {
            satisHareket.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString()) ;
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}