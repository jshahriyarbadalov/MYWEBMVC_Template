using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MYWEBMVC_Template.App_Classes;

namespace MYWEBMVC_Template.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            MembershipUserCollection users= Membership.GetAllUsers();
            return View(users);
        }
        [AllowAnonymous]
        public ActionResult Add()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Add(User u)
        {
            MembershipCreateStatus status;
            Membership.CreateUser(u.Username,u.Password,u.Email,u.SecretQuestion,u.SecretAnswer, true, out status);
            string message = " ";
            switch (status)
            {
                case MembershipCreateStatus.Success:
                   
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    message += " Invalid Username!";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    message += " Invalid Password!";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    message += " Invalid Question!";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    message += " Ivalid Secret Answer!";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    message += " Invalid email address!";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    message += " This username used!";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    message += " This mail used!";
                    break;
                case MembershipCreateStatus.UserRejected:
                    message += " User Rejected!";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    message += " Invalid Provider user key!";
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    message += " This key used error!";
                    break;
                case MembershipCreateStatus.ProviderError:
                    message += " Provider Error!";
                    break;
                default:
                    break;
            }

            ViewBag.Message = message;
            if (status == MembershipCreateStatus.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [Authorize(Roles="Admin")]
        public ActionResult RoleFather()
        {
            ViewBag.Roles = Roles.GetAllRoles().ToList();
            ViewBag.Users = Membership.GetAllUsers();
            return View();
        }

        [Authorize(Roles="Admin")]
        [HttpPost]
        public ActionResult RoleFather(string Username, string RoleName)
        {
            Roles.AddUserToRole(Username,RoleName);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string MemberRoles(string username)
        {
            List<string> rolList = Roles.GetRolesForUser(username).ToList();
            string rol = " ";
            foreach (string r in rolList)
            {
                rol += r + "-";
            }

            rol = rol.Remove(rol.Length - 1, 1);
            return rol;
        }
    }
}