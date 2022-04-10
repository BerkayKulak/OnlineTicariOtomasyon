using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;
using PagedList;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        private Context context = new Context();
        private string connection =
            "data source=(localdb)\\MSSQLLocalDB;initial catalog=KfauAutomationProject;integrated security=True";
        public ActionResult Index()

        {
            DataTable dtbDataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                // create Procedure SelectKategoris
                // as
                // select * from Kategoris
                SqlDataAdapter sqlData =
                    new SqlDataAdapter("select * from FinGorselName", sqlConnection);
                sqlData.Fill(dtbDataTable);
            }
            // var degerler = context.SatisHarekets.ToList();
            return View(dtbDataTable);
        }
    }
}