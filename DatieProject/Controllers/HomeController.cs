using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatieProject.Models;

namespace DatieProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatieDBEntities _datieDb = new DatieDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var data = _datieDb.tbl_User.ToList();
            var dt = new List<UserModel>();
            data.ForEach(x =>
            {
                var tmp = new UserModel
                {
                    Username = x.username,
                    RegDate = x.reg_date.ToString(),
                    IsAdmin = x.isAdmin,
                    IsActive = x.isActive
                };
                dt.Add(tmp);
            });

            return Json(new { data = dt.OrderBy(x => x.RegDate) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeStatus(string id, string status)
        {
            var data = _datieDb.tbl_User.ToList().Find(x => x.username.Equals(id));
            if (data != null)
            {
                if (status.Equals("Active"))
                {
                    data.isActive = true;
                }
                else
                {
                    data.isActive = false;
                }
                _datieDb.Entry(data).State = EntityState.Modified;
                var check = _datieDb.SaveChanges();
                if (check > 0)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }            
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
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