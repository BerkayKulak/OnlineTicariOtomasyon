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
            UrunveDetay detay = new UrunveDetay();
            //var degerler = context.Uruns.Where(x => x.UrunId == 2).ToList();
            detay.Deger1 = context.Uruns.Where(x => x.UrunId == 2).ToList();
            detay.Deger2 = context.Detays.Where(y => y.DetayID == 1).ToList();
            return View(detay);
        }
    }
}