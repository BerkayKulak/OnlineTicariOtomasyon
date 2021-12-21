using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        private Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Departmans.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            context.Departmans.Add(departman);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}