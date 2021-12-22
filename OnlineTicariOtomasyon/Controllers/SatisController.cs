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
    public class SatisController : Controller
    {
        // GET: Satis
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
                    new SqlDataAdapter("SELECT SatisId,UrunAd,CariAd,PersonelAd,Adet,Fiyat,ToplamTutar,Tarih,SH.PersonelId" +
                                       "\r\nFROM SatisHarekets as SH" +
                                       "\r\nINNER JOIN Uruns AS U" +
                                       "\r\nON U.UrunId = SH.UrunId  " +
                                       "\r\nINNER JOIN Personels AS p" +
                                       "\r\nON P.PersonelId = SH.PersonelId" +
                                       "\r\nINNER JOIN Carilers AS C" +
                                       "\r\nON C.CariId = SH.CariId \r\n", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            // var degerler = context.SatisHarekets.ToList();
            return View(dtbDataTable);
        } 

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in context.Uruns.ToList()
                select new SelectListItem()
                {
                    Text = x.UrunAd,
                    Value = x.UrunId.ToString()
                }).ToList();

            List<SelectListItem> deger2 = (from x in context.Carilers.ToList()
                select new SelectListItem()
                {
                    Text = x.CariAd,
                    Value = x.CariId.ToString()
                }).ToList();

            List<SelectListItem> deger3 = (from x in context.Personels.ToList()
                select new SelectListItem()
                {
                    Text = x.PersonelAd,
                    Value = x.PersonelId.ToString()
                }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satisHareket)
        {
            //satisHareket.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

            //context.SatisHarekets.Add(satisHareket);
            DataTable dtbDataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData =
                    new SqlDataAdapter($"insert into SatisHarekets " +
                                       $"(UrunId,CariId,PersonelId,Adet,Fiyat,ToplamTutar,Tarih)" +
                                       $"\r\nvalues ('{satisHareket.UrunId}','{satisHareket.CariId}'," +
                                       $"'{satisHareket.PersonelId}','{satisHareket.Adet}'," +
                                       $"'{satisHareket.Fiyat}','{satisHareket.ToplamTutar}',GETDATE()); ", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
       
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Uruns.ToList()
                select new SelectListItem()
                {
                    Text = x.UrunAd,
                    Value = x.UrunId.ToString()
                }).ToList();

            List<SelectListItem> deger2 = (from x in context.Carilers.ToList()
                select new SelectListItem()
                {
                    Text = x.CariAd,
                    Value = x.CariId.ToString()
                }).ToList();

            List<SelectListItem> deger3 = (from x in context.Personels.ToList()
                select new SelectListItem()
                {
                    Text = x.PersonelAd,
                    Value = x.PersonelId.ToString()
                }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = context.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }

        public ActionResult SatisGuncelle(SatisHareket satisHareket)
        {
            var deger = context.SatisHarekets.Find(satisHareket.SatisId);
            deger.CariId = satisHareket.CariId;
            deger.Adet = satisHareket.Adet;
            deger.Fiyat = satisHareket.Fiyat;
            deger.PersonelId = satisHareket.PersonelId;
            deger.Tarih = satisHareket.Tarih;
            deger.ToplamTutar = satisHareket.ToplamTutar;
            deger.UrunId = satisHareket.UrunId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.SatisId == id).ToList();
            return View(degerler);
        }

    }
}