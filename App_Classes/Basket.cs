using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MYWEBMVC_Template.App_Classes
{
    using Models;
    public class Basket
    {
        private  List<Product> products =new List<Product>();

        public  List<Product> prods
        {
            get{
                return products;
            }
            set{
                products = value;
            }
            
        }
    }
}