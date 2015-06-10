using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatieProject.Controllers
{
    public class DatieController : Controller
    {
        DatieDBEntities _db = new DatieDBEntities();
        //
        // GET: /Datie/
        public ActionResult Index()
        {
            return View();
        }

	}
}