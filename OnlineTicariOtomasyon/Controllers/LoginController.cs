using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Models.Sınıflar
{
    public class LoginController : Controller
    {
        // GET: Login
        private Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Cariler cariler)
        {
            context.Carilers.Add(cariler);
            context.SaveChanges();
            return PartialView();
        }
    }
}
