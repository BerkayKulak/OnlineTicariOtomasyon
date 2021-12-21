using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        private Context context = new Context();
        public ActionResult Index()
        {
            var urunler = context.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            // dropdown yaratıyoruz. texti adı olacak, valuesi ise idsi olacak
            List<SelectListItem> deger1 = (from x in context.Kategoris.ToList()
                select new SelectListItem
                {
                    Text = x.KategoriAd,
                    Value = x.KategoriID.ToString()
                }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = context.Uruns.Find(id);
            deger.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Kategoris.ToList()
                select new SelectListItem
                {
                    Text = x.KategoriAd,
                    Value = x.KategoriID.ToString()
                }).ToList();

            ViewBag.dgr1 = deger1;
            var urundeger = context.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
    }
}