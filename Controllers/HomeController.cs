using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MYWEBMVC_Template.Controllers
{
    using Models;
    using App_Classes;
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ActiveUser = HttpContext.Application["ActiveUser"];
            ViewBag.TotalVisitor = HttpContext.Application["TotalVisitor"];
            return View();
        }

        public ActionResult CookieFather()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CookieFather(string CookieName, string CookieValue)
        {
            HttpCookie ck=new HttpCookie(CookieName);
            ck.Value = CookieValue;
            ck.Expires=DateTime.Now.AddDays(1);
            Response.Cookies.Add(ck);
            return View();
        }

        public ActionResult CookieRead()
        {
           string values= Request.Cookies["Group Code"].Value;
           ViewBag.Cerez = values; 
           return View();
        }

        public ActionResult Basketing()
        {
            List<Product> products=new List<Product>();
            if (Session["ActiveBasket"] != null)
            {
                Basket b = (Basket) Session["ActiveBasket"];
                products = b.prods;
            }
            return View(products);
        }
    }
}