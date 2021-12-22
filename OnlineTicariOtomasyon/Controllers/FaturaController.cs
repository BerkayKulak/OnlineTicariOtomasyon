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
    }
}