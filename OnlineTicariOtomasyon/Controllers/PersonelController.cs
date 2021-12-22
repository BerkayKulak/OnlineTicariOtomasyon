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
    public class PersonelController : Controller
    {
        // GET: Personel
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
                    new SqlDataAdapter("select PersonelAd,PersonelSoyad,PersonelGorsel,DepartmanAd,P.PersonelId" +
                                       "\r\nfrom Personels as P" +
                                       "\r\ninner join Departmen as D" +
                                       "\r\non D.DepartmanId=P.DepartmanId", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            // var degerler = context.SatisHarekets.ToList();
            return View(dtbDataTable);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        { 
            List<SelectListItem> deger1 = (from x in context.Departmans.ToList()
                select new SelectListItem
                {
                    Text = x.DepartmanAd,
                    Value = x.DepartmanId.ToString()
                }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            DataTable dtbDataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData =
                    new SqlDataAdapter($"INSERT INTO Personels " +
                                       $"(PersonelAd,PersonelSoyad,PersonelGorsel,DepartmanId)" +
                                       $"\r\nVALUES ('{personel.PersonelAd}','{personel.PersonelSoyad}'," +
                                       $"'{personel.PersonelGorsel}','{personel.DepartmanId}');", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Departmans.ToList()
                select new SelectListItem
                {
                    Text = x.DepartmanAd,
                    Value = x.DepartmanId.ToString()
                }).ToList();

            ViewBag.dgr1 = deger1;
            var personel = context.Personels.Find(id);
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(Personel personel)
        {
            DataTable dtbDataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData =
                    new SqlDataAdapter($"UPDATE Personels" +
                                       $"\r\nSET PersonelAd = '{personel.PersonelAd}', " +
                                       $"\r\nPersonelSoyad= '{personel.PersonelSoyad}'," +
                                       $"\r\nPersonelGorsel = '{personel.PersonelGorsel}'," +
                                       $"\r\nDepartmanId = {personel.DepartmanId}" +
                                       $"\r\nWHERE PersonelId = {personel.PersonelId};", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            //var prs = context.Personels.Find(personel.PersonelId);
            //prs.PersonelAd = personel.PersonelAd;
            //prs.PersonelSoyad = personel.PersonelSoyad;
            //prs.PersonelGorsel = personel.PersonelGorsel;
            //prs.DepartmanId = personel.DepartmanId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}