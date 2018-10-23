using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TreinamentoAula1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Pagination",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Users", action = "Index", name = UrlParameter.Optional, ldapldapuid = UrlParameter.Optional, optradio = UrlParameter.Optional, page = UrlParameter.Optional }
            );
        }
    }
}
