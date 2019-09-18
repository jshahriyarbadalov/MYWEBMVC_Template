using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MYWEBMVC_Template.Models;

namespace MYWEBMVC_Template.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        NorthwndContext ctx=new NorthwndContext();
        public ActionResult Index()
        {
            List<Category> ctg = ctx.Categories.ToList();
            return View(ctg);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category ctg)
        {
            ctx.Categories.Add(ctg);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public void Delete(int id)
        {
            Category c = ctx.Categories.FirstOrDefault(x=>x.CategoryID==id);
            ctx.Categories.Remove(c);
            ctx.SaveChanges();
            
        }
    }
}