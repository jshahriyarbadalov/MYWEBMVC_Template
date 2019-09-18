using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MYWEBMVC_Template.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            List<string> roList= Roles.GetAllRoles().ToList();
            return View(roList);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string RoleName)
        {
            Roles.CreateRole(RoleName);
            return RedirectToAction("Index");
        }
    }
}