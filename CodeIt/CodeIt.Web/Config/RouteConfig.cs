﻿using System.Web.Mvc;
using System.Web.Routing;

namespace CodeIt.Web.Config
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Challenge",
                url: "Challenge/{action}/{title}",
                defaults: new { controller = "Challenge", action = "Index", title = UrlParameter.Optional },
                namespaces: new[] { "CodeIt.Web.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "CodeIt.Web.Controllers" });
        }
    }
}
