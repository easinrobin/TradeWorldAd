using System.Web.Mvc;
using TW.BusinessLayer;
using TW.Models;

namespace TwAdmin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var data = UserManager.GetUserByUserNameNPassword(user.UserName.Trim(), user.Password.Trim());
            if (data != null)
            {
                Session["UserID"] = data.UserId.ToString();
                Session["UserName"] = data.UserName.ToString();
                Session["Name"] = "Site Admin";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrMsg = "Please enter email and password!.";
            }

            return View(user);
        }
    }
}