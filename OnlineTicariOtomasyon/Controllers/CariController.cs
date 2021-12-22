using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        private string connection =
            "data source=(localdb)\\MSSQLLocalDB;initial catalog=KfauAutomationProject;integrated security=True";
        public ActionResult Index()
        {
            DataTable dtbDataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData =
                    new SqlDataAdapter("select * from Carilers where Durum = 'True'", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            // var degerler = context.SatisHarekets.ToList();
            return View(dtbDataTable);
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cariler cariler)
        {
            cariler.Durum = true;
            context.Carilers.Add(cariler);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            DataTable dtbDataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData =
                    new SqlDataAdapter($"Delete From Carilers where CariId='{id}'", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = context.Carilers.Find(id);
            return View("CariGetir", cari);
        }

        public ActionResult CariGuncelle(Cariler cariler)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = context.Carilers.Find(cariler.CariId);
            cari.CariAd = cariler.CariAd;
            cari.CariSoyad = cariler.CariSoyad;
            cari.CariSehir = cariler.CariSehir;
            cari.CariMail = cariler.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.CariId == id).ToList();
            var cari = context.Carilers.Where(x => x.CariId == id).Select(y => y.CariAd).FirstOrDefault();
            ViewBag.cari = cari;
            return View(degerler);
        }

    }
}