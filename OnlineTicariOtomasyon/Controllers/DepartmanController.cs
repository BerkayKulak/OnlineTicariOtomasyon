using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;
using PagedList;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        // GET: Departman
        private Context context = new Context();
    
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = context.Departmans.ToList().ToPagedList(sayfa, 4);
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

        public ActionResult DepartmanSil(int id)
        {
            var departman = context.Departmans.Find(id);
            departman.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = context.Departmans.Find(id);
            return View("DepartmanGetir", departman);
        }

        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var dept = context.Departmans.Find(departman.DepartmanId);
            dept.DepartmanAd = departman.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = context.Personels.Where(x => x.DepartmanId == id).ToList();
            var dpt = context.Departmans.Where(x => x.DepartmanId == id).Select(y=>y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }


        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var personel = context.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd).FirstOrDefault();
            ViewBag.p = personel;
            return View(degerler);
        }
    }
}