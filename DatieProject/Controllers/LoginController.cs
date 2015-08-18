using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using DatieProject.Models;

namespace DatieProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly DatieDBEntities _datieDb = new DatieDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("HomePage", "Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Login");
            var checkLogin =
                _datieDb.tbl_User.ToList()
                    .Find(x => x.username.Equals(model.UserName) && x.password.Equals(model.Password));
            var user = new ApplicationUser();
            if (checkLogin != null)
            {
                if (checkLogin.isAdmin)
                {
                    if (checkLogin.isActive)
                    {
                        var info = new Info
                        {
                            Username = checkLogin.username,
                            IsAdmin = checkLogin.isAdmin,
                            IsActive = checkLogin.isActive,
                            IsAdminMaster = checkLogin.admin_master
                        };
                        user.Info = info;
                        Session["User"] = user;
                        return RedirectToLocal(returnUrl);
                    }
                    Session["Error"] = "This account is deactivated!";
                }
                else
                {
                    Session["Error"] = "This account don't have permission to login!";
                }
            }
            else
            {
                Session["Error"] = "Invalid username or password. Try Again!";
            }
            // If we got this far, something failed, redisplay form
            return RedirectToAction("Index", "Login");
        }

        //
        // POST: /Account/LogOff
        public ActionResult LogOff()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}