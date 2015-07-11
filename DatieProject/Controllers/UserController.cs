using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DatieProject.Models;

namespace DatieProject.Controllers
{
    public class UserController : Controller
    {
        private readonly DatieDBEntities _datieDb = new DatieDBEntities();
        //
        // GET: /User/
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

            return Json(new {data = dt.OrderBy(x => x.RegDate)}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeStatus(string id, string status)
        {
            //Check id is avaliable on database
            var data = _datieDb.tbl_User.ToList().Find(x => x.username.Equals(id));
            var session = (ApplicationUser) Session["User"];
            if (session.Info.IsAdmin)
            {
                if (data != null)
                {
                    //check status can change (deactivete to active)
                    if (status.Equals("Active"))
                    {
                        if (data.isAdmin)
                        {
                            //Check user login is admin master. Only admin master can active admin account
                            if (session.Info.IsAdminMaster)
                            {
                                data.isActive = true;
                            }
                            return Json(new {success = false}, JsonRequestBehavior.AllowGet);
                        }
                        data.isActive = true;
                    }
                    //else, change active to deactive
                    else
                    {
                        //if user can change role is admin, check user is loged is master admin
                        if (data.isAdmin)
                        {
                            //Check user login is admin master. Only admin master can deactivate admin account
                            if (session.Info.IsAdminMaster)
                            {
                                data.isActive = false;
                            }
                            return Json(new {success = false}, JsonRequestBehavior.AllowGet);
                        }
                        data.isActive = false;
                    }
                    _datieDb.Entry(data).State = EntityState.Modified;
                    var check = _datieDb.SaveChanges();
                    if (check > 0)
                    {
                        return Json(new {success = true}, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(new {success = false}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeRole(string id, string status)
        {
            var data = _datieDb.tbl_User.ToList().Find(x => x.username.Equals(id));
            if (data != null)
            {
                if (status.Equals("Admin"))
                {
                    data.isAdmin = true;
                }
                else
                {
                    if (data.isAdmin)
                    {
                        //Check user login is admin master. Only admin master can deactivate admin account
                        return Json(new {success = false}, JsonRequestBehavior.AllowGet);
                    }
                    data.isAdmin = false;
                }
                _datieDb.Entry(data).State = EntityState.Modified;
                var check = _datieDb.SaveChanges();
                if (check > 0)
                {
                    return Json(new {success = true}, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new {success = false}, JsonRequestBehavior.AllowGet);
        }
    }
}