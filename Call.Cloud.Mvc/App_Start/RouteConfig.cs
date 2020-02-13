 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Call.Cloud.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Agent",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login_user", action = "Login_user", id = UrlParameter.Optional }
            );
        }
    }
}
