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
    public class UrunController : Controller
    {
        // GET: Urun
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
                    new SqlDataAdapter("select U.UrunId, UrunAd,Marka,Stok,AlisFiyat,SatisFiyat,KategoriAd,UrunGorsel,Durum" +
                                       "\r\nfrom Uruns  as U" +
                                       "\r\ninner join Kategoris as K" +
                                       "\r\non K.KategoriID = U.KategoriID" +
                                       "\r\nwhere Durum = 'True'\r\n", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
        
            //var urunler = context.Uruns.Where(x => x.Durum == true).ToList();
            return View(dtbDataTable);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            // dropdown yaratıyoruz. texti adı olacak, valuesi ise idsi olacak
            List<SelectListItem> deger1 = (from x in context.Kategoris.ToList()
                select new SelectListItem
                {
                    Text = x.KategoriAd,
                    Value = x.KategoriID.ToString()
                }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            DataTable dtbDataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData =
                    new SqlDataAdapter($"INSERT INTO Uruns(UrunAd,Marka,Stok,AlisFiyat,SatisFiyat,KategoriID,UrunGorsel,Durum)" +
                                       $"\r\nVALUES ('{urun.UrunAd}', '{urun.Marka}','{urun.Stok}', " +
                                       $"'{urun.AlisFiyat}', '{urun.SatisFiyat}', " +
                                       $"'{urun.KategoriID}', '{urun.UrunGorsel}','{urun.Durum}');", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            DataTable dtbDataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData =
                    new SqlDataAdapter($"DELETE FROM Uruns WHERE UrunId='{id}';", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Kategoris.ToList()
                select new SelectListItem
                {
                    Text = x.KategoriAd,
                    Value = x.KategoriID.ToString()
                }).ToList();

            ViewBag.dgr1 = deger1;
            var urundeger = context.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }

        public ActionResult UrunGuncelle(Urun urun)
        {
            //var urn = context.Uruns.Find(urun.UrunId);
            //urn.AlisFiyat = urun.AlisFiyat;
            //urn.Durum = urun.Durum;
            //urn.KategoriID = urun.KategoriID;
            //urn.Marka = urun.Marka;
            //urn.SatisFiyat = urun.SatisFiyat;
            //urn.Stok = urun.Stok;
            //urn.UrunAd = urun.UrunAd;
            //urn.UrunGorsel = urun.UrunGorsel;

            DataTable dtbDataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData =
                    new SqlDataAdapter($"UPDATE Uruns" +
                                       $"\r\nSET " +
                                       $"\r\nAlisFiyat = '{urun.AlisFiyat}', " +
                                       $"\r\nDurum= '{urun.Durum}'," +
                                       $"\r\nKategoriID = '{urun.KategoriID}'," +
                                       $"\r\nMarka = '{urun.Marka}'," +
                                       $"\r\nSatisFiyat = '{urun.SatisFiyat}'," +
                                       $"\r\nStok = '{urun.Stok}'," +
                                       $"\r\nUrunAd = '{urun.UrunAd}'," +
                                       $"\r\nUrunGorsel = '{urun.UrunGorsel}'\r\n" +
                                       $"WHERE UrunId = {urun.UrunId};", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}