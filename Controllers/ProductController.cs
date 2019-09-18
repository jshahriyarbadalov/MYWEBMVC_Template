using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MYWEBMVC_Template.App_Classes;
using MYWEBMVC_Template.Models;

namespace MYWEBMVC_Template.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        NorthwndContext ctx=new NorthwndContext();

        public ActionResult Index()
        {
            List<Product> products = ctx.Products.ToList();
            return View(products);
        }

        public ActionResult AddProduct()
        {
            ViewBag.Categories = ctx.Categories.ToList();
            ViewBag.Suppliers = ctx.Suppliers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            ctx.Products.Add(p);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete( int id)
        {
            Product p = ctx.Products.FirstOrDefault(x => x.ProductID == id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(Product p)
        {
            Product pr = ctx.Products.FirstOrDefault(x => x.ProductID == p.ProductID);
            ctx.Products.Remove(pr);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductDetail()
        {
            int id=Convert.ToInt32(Request.QueryString["id"].ToString());
            string name = Request.QueryString["name"].ToString();
            Product p = ctx.Products.FirstOrDefault(x => x.ProductID == id);
            return View(p);
        }
        [HttpPost]
        public void AddBasket(int id)
        {
            Basket b;
            if (Session["ActiveBasket"] == null)
            {
                b=new Basket();
            }
            else
            {
                 b = (Basket) Session["ActiveBasket"];
            }
            Product p = ctx.Products.FirstOrDefault(x => x.ProductID == id);
            b.prods.Add(p);
            Session["ActiveBasket"] = b;
        }
    }
}