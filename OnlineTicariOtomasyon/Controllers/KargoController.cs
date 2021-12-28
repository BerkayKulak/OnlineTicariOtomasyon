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
            Random random = new Random();
            string[] karakterler = new[] {"A", "B", "C", "D"};
            int karakter1, karakter2, karakter3;
            karakter1 = random.Next(0, 4);
            karakter2 = random.Next(0, 4);
            karakter3 = random.Next(0, 4);
            int s1, s2, s3;
            s1 = random.Next(100, 1000);
            s2 = random.Next(10, 99);
            s3 = random.Next(10, 99);
            string kod = s1.ToString() + karakterler[karakter1] + s2 + karakterler[karakter2] + s3 +
                         karakterler[karakter3];
            ViewBag.takipkod = kod;
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