using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MYWEBMVC_Template.Controllers
{
    using App_Classes;
    using System.Web.Security;
    [Authorize]
    public class MembershipController : Controller
    {
        // GET: Membership
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User u, string remember)
        {
            bool result = Membership.ValidateUser(u.Username, u.Password);
            if (result)
            {
                if (remember == "on")
                {
                    FormsAuthentication.RedirectFromLoginPage(u.Username, true);

                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(u.Username, false);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Username or Password incorrect!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ForgotPassword(User u)
        {
            MembershipUser mu = Membership.GetUser(u.Username);
            if (mu.PasswordQuestion == u.SecretQuestion){
               string pwd= mu.ResetPassword(u.SecretAnswer);
               mu.ChangePassword(pwd, u.Password);
               return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Message = "This information incorrect!";
                return View();
            }
        }
    }
}