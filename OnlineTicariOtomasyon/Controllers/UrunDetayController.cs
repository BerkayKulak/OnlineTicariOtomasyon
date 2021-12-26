using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        private Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Uruns.Where(x => x.UrunId == 2).ToList();
            return View(degerler);
        }
    }
}