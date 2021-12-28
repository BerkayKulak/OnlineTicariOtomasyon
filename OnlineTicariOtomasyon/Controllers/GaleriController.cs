using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;
using PagedList;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        private Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Uruns.ToList();
            return View(degerler);
        }
    }
}