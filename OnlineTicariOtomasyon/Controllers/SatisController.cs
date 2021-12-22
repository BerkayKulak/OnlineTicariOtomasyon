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
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satisHareket)
        {
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}