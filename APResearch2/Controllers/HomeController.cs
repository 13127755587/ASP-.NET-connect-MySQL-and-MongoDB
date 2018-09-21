using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APResearch2.Models;

namespace APResearch2.Controllers
{
    public class HomeController : Controller
    {
        private Conn conn = new Conn();
        public ActionResult Index()
        {
            return View(conn.GetAllTasks());
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