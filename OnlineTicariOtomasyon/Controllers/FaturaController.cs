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
        public ActionResult Index(string p)
        {
            //var liste = context.Faturalars.ToList();
            var liste = from x in context.Faturalars select x;
            if (!string.IsNullOrEmpty(p))
            {
                liste = liste.Where(y => y.VergiDairesi.Contains(p));
            }
            return View(liste.ToList());
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

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem faturaKalem)
        {
            context.FaturaKalems.Add(faturaKalem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dinamik()
        {
            Class4 cs  = new Class4();
            cs.deger1 = context.Faturalars.ToList();
            cs.deger2 = context.FaturaKalems.ToList();
            return View(cs);
        }

        public ActionResult FaturaKaydet(string FaturaSeriNo,string FaturaSıraNo,DateTime Tarih, string VergiDairesi, string Saat,string TeslimEden, string TeslimAlan,string Toplam,int UrunId,FaturaKalem[] kalemler)
        {
            Faturalar faturalar = new Faturalar();
            faturalar.FaturaSeriNo = FaturaSeriNo;
            faturalar.FaturaSıraNo = FaturaSıraNo;
            faturalar.Tarih = Tarih;
            faturalar.VergiDairesi = VergiDairesi;
            faturalar.Saat = Saat;
            faturalar.TeslimEden = TeslimEden;
            faturalar.TeslimAlan = TeslimAlan;
            faturalar.Toplam = decimal.Parse(Toplam);
            faturalar.UrunId = UrunId;
            context.Faturalars.Add(faturalar);
            foreach (var x in kalemler)
            {
                FaturaKalem faturaKalem = new FaturaKalem();
                faturaKalem.Aciklama = x.Aciklama;
                faturaKalem.BirimFiyat = x.BirimFiyat;
                faturaKalem.FaturaId = x.FaturaKalemId;
                faturaKalem.Tutar = x.Tutar;
                context.FaturaKalems.Add(faturaKalem);
            }
            context.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}