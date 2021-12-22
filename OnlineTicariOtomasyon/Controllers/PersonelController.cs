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
    }
}