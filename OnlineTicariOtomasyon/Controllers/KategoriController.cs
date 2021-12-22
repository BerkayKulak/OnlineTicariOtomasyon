using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OnlineTicariOtomasyon.Models.Sınıflar;
using Context = OnlineTicariOtomasyon.Models.Sınıflar.Context;

namespace OnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
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
                    new SqlDataAdapter("select * from Kategoris", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            // var degerler = context.SatisHarekets.ToList();
            return View(dtbDataTable);
        }

        [HttpGet]
        // form yüklendiği zaman burayı çalıştır
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        // butonu tıklayınca burayı çalıştır.
        public ActionResult KategoriEkle(Kategori kategori)
        {
            DataTable dtbDataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData =
                    new SqlDataAdapter($"INSERT INTO Kategoris(KategoriAd)\r\nVALUES ('{kategori.KategoriAd}');", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            DataTable dtbDataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData =
                    new SqlDataAdapter($"DELETE FROM Kategoris WHERE KategoriID={id};", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = context.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            DataTable dtbDataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData =
                    new SqlDataAdapter($"UPDATE Kategoris" +
                                       $"\r\nSET KategoriAd = '{kategori.KategoriAd}'" +
                                       $"\r\nWHERE KategoriID = {kategori.KategoriID};", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}