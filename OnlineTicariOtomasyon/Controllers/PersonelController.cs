using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        private Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        { 
            List<SelectListItem> deger1 = (from x in context.Departmans.ToList()
                select new SelectListItem
                {
                    Text = x.DepartmanAd,
                    Value = x.DepartmanId.ToString()
                }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Departmans.ToList()
                select new SelectListItem
                {
                    Text = x.DepartmanAd,
                    Value = x.DepartmanId.ToString()
                }).ToList();

            ViewBag.dgr1 = deger1;
            var personel = context.Personels.Find(id);
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(Personel personel)
        {
            var prs = context.Personels.Find(personel.PersonelId);
            prs.PersonelAd = personel.PersonelAd;
            prs.PersonelSoyad = personel.PersonelSoyad;
            prs.PersonelGorsel = personel.PersonelGorsel;
            prs.DepartmanId = personel.DepartmanId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}