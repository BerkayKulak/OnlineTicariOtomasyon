using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        private Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Carilers.ToList();
            return View(degerler);
        }
        
    }
}