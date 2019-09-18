using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MYWEBMVC_Template
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start()
        {
            if (Application["ActiveUser"]==null)
            {
                int count = 1;
                Application["ActiveUser"] = count;
            }
            else
            {
                int count = (int) Application["ActiveUser"];
                count++;
                Application["ActiveUser"] = count;
            }

            if (Application["TotalVisitor"] == null)
            {
                int count = 1;
                Application["TotalVisitor"]=count;
            }
            else
            {
                int count = (int) Application["TotalVisitor"];
                count++;
                Application["ActiveUser"] = count;
            }
        }
        protected void Session_End()
        {
            int count = (int) Application["ActiveUser"];
            count--;
            Application["ActiveUser"] = count;
        }
    }
}
