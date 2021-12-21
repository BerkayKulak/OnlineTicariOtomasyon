using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OnlineTicariOtomasyon.Models.Sınıflar;
using Context = OnlineTicariOtomasyon.Models.Sınıflar.Context;

namespace OnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        private Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Kategoris.ToList();
            return View(degerler);
        }

        [HttpGet]
        // form yüklendiği zaman burayı çalıştır
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        // butonu tıklayınca burayı çalıştır.
        public ActionResult KategoriEkle(Kategori kategori)
        {
            context.Kategoris.Add(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = context.Kategoris.Find(id);
            context.Kategoris.Remove(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}