﻿using System.Web.Mvc;

namespace DatieProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatieDBEntities _datieDb = new DatieDBEntities();

        public ActionResult Index()
        {
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