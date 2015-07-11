using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using DatieProject.Models;

namespace DatieProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly DatieDBEntities _datieDb = new DatieDBEntities();

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var checkLogin =
                    _datieDb.tbl_User.ToList()
                        .Find(x => x.username.Equals(model.UserName) && x.password.Equals(model.Password));
                var user = new ApplicationUser();
                if (checkLogin != null)
                {
                    if (checkLogin.isAdmin)
                    {
                        var info = new Info
                        {
                            Username = checkLogin.username,
                            IsAdmin = checkLogin.isAdmin,
                            IsActive = checkLogin.isActive
                            // IsAdminMaster = (bool) checkLogin.admin_master
                        };
                        user.Info = info;
                        Session["User"] = user;
                        return RedirectToLocal(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return RedirectToLocal(returnUrl);
        }

        //
        // POST: /Account/LogOff
        public ActionResult LogOff()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}