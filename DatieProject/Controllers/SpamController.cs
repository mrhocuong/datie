using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DatieProject.Models;

namespace DatieProject.Controllers
{
    public class SpamController : Controller
    {
        private readonly DatieDBEntities _datieDb = new DatieDBEntities();
        // GET: Spam
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var data = _datieDb.tbl_Comment.OrderByDescending(x=>x.date_cmt).ToList();
            var dt = new List<SpamModel>();

            data.ForEach(x =>
            {
                var tmp = new SpamModel
                {
                    IdCmt = x.id_cmt,
                    IdShop = x.id_shop,
                    Comment = x.comment,
                    DateCmt = x.date_cmt.ToShortDateString(),
                    Username = x.username
                };
                dt.Add(tmp);
            });

            return Json(new {data = dt}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteComment(int id)
        {
            var data = _datieDb.tbl_Comment.ToList().Find(x => x.id_cmt.Equals(id));
            if (data != null)
            {
                _datieDb.tbl_Comment.Attach(data);
                _datieDb.tbl_Comment.Remove(data);
                _datieDb.SaveChanges();
                return Json(new {success = true}, JsonRequestBehavior.AllowGet);
            }
            return Json(new {success = false}, JsonRequestBehavior.AllowGet);
        }
    }
}