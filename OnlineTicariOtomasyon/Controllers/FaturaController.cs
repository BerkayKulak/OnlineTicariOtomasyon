using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        private Context context = new Context();
        public ActionResult Index()
        {
            var liste = context.Faturalars.ToList();
            return View(liste);
        }
        
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar faturalar)
        {
            context.Faturalars.Add(faturalar);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = context.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar faturalar)
        {
            var fatura = context.Faturalars.Find(faturalar.FaturaId);
            fatura.FaturaSeriNo = faturalar.FaturaSeriNo;
            fatura.FaturaSıraNo = faturalar.FaturaSıraNo;
            fatura.VergiDairesi = faturalar.VergiDairesi;
            fatura.Saat = faturalar.Saat;
            fatura.Tarih = faturalar.Tarih;
            fatura.TeslimAlan = faturalar.TeslimAlan;
            fatura.TeslimEden = faturalar.TeslimEden;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = context.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            return View(degerler);
        }
    }
}