using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        private Context context = new Context();
        public ActionResult Index()
        {
            var kargolar = context.KargoDetays.ToList();
            return View(kargolar);
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(KargoDetay kargoDetay)
        {
            context.KargoDetays.Add(kargoDetay);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}