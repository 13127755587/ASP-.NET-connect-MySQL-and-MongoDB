using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;  //added by Damine at MS support
using System.Data;           //added by Damine at MS Support 
using System.Data.SqlClient;  //added by Damine at MS Support
using test01.Models;

namespace test01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;//read the connection string from web.config
            string sqlQuery01 = "select * from dbo.OOO_DesignParam";
            var list_obj = new List<OOO_ConfDataClass>();
            using (SqlConnection con = new SqlConnection(conn))   // Using "using" auto open and close the connection. 
            {
                SqlCommand cmd = new SqlCommand(sqlQuery01,con); 
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var temp = new OOO_ConfDataClass();
                    temp.Id = rdr["ID"].ToString();
                    temp.voltage_low = rdr["Voltage_Low"].ToString();
                    temp.voltage_high = rdr["Volate_High"].ToString();
                    temp.threshhold_high = rdr["Threshold_High"].ToString();
                    temp.threshhold_low = rdr["Threshold_Low"].ToString();
                    list_obj.Add(temp);

                }

            }
                return View(list_obj);
        }
        public ActionResult Home()
        {
            ViewBag.Message = "Home Page TBD";
            return View();
        }
        public ActionResult Application_name()
        {
            ViewBag.Message = "Cricital Design Parameters";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}