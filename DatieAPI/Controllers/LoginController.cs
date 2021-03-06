﻿using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DatieAPI.Models;

namespace DatieAPI.Controllers
{
    public class LoginController : ApiController
    {
        private readonly DatieDBEntities _datieDb = new DatieDBEntities();

        public ApplicationUser Post(LoginViewModel model)
        {
            var checkLogin =
                _datieDb.tbl_User.FirstOrDefault(
                    x => x.username.Equals(model.UserName) && x.password.Equals(model.Password));

            if (checkLogin == null) return null;
            var user = new ApplicationUser();
            if (checkLogin.isActive)
            {
                user.Username = checkLogin.username;
                user.IsAdmin = checkLogin.isAdmin;
                user.IsActive = checkLogin.isActive;
                user.IsAdminMaster = checkLogin.admin_master;
                
            }
            else
            {
                user.IsActive = checkLogin.isActive;
            }
            return user;
        }

        //public bool GetLogOff()
        //{
        //    var session = HttpContext.Current.Session;
        //    if (session["User"] != null)
        //    {
        //        session["User"] = null;
        //        return true;
        //    }
        //    return false;
        //}
      
    }
}