using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        private Context context = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var carimail = (string) Session["CariMail"];
            var degerler = context.Carilers.FirstOrDefault(x => x.CariMail == carimail);
            ViewBag.m = carimail;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var carimail = (string)Session["CariMail"];
            var id = context.Carilers.Where(x => x.CariMail == carimail.ToString()).Select(y=>y.CariId).FirstOrDefault();
            var degerler = context.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }
    }
}