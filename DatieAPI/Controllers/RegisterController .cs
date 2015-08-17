using System;
using System.Linq;
using System.Web.Http;
using DatieAPI.Models;

namespace DatieAPI.Controllers
{
    public class RegisterController : ApiController
    {
        private readonly DatieDBEntities _datieDb = new DatieDBEntities();

        public Register PostRegister(LoginViewModel model)
        {
            var res = new Register();
            if (model.UserName == "")
            {
                res.Message = "Username cannot null!";
                return res;
            }
            if (model.Password == "")
            {
                res.Message = "Password cannot null!";
                return res;
            }
            
            var checkLogin =
                _datieDb.tbl_User.FirstOrDefault(
                    x => x.username.Equals(model.UserName) && x.password.Equals(model.Password));

            if (checkLogin == null)
            {
                var data = new tbl_User
                {
                    username = model.UserName,
                    password = model.Password,
                    reg_date = DateTime.Now,
                    admin_master = false,
                    isActive = true,
                    isAdmin = false
                };
                try
                {
                    _datieDb.tbl_User.Add(data);
                    var check = _datieDb.SaveChanges();
                    if (check > 0)
                    {
                        res.UserName = model.UserName;
                        res.Success = true;
                    }
                }
                catch (Exception e)
                {
                    res.Message = "Have error, please try again";
                }
            }
            res.Message = "Username is avaliable!";
            return res;
        }
    }
}