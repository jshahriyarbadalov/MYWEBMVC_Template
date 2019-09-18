using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MYWEBMVC_Template.Models;

namespace MYWEBMVC_Template.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        NorthwndContext ctx=new NorthwndContext();
        public ActionResult Index()
        {
            List<Supplier> sup = ctx.Suppliers.ToList();
            return View(sup);
        }

        [HttpPost]
        public string Delete(int id)
        {
            Supplier s = ctx.Suppliers.FirstOrDefault(x => x.SupplierID == id);
            ctx.Suppliers.Remove(s);
            try
            {
                ctx.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
                return "error";
            }
            
        }
    }
}