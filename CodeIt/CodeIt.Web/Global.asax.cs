using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using CodeIt.Web.Config;
using CodeIt.Web.Infrastructure.Mapping;
using Microsoft.AspNet.Identity;

namespace CodeIt.Web
{
    public class CodeItApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Only Razor Engine
            ViewEnginesConfig.Configure();

            DbConfig.Initialize();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var mapConfig = new AutoMapperConfig();
            mapConfig.Execute(Assembly.GetExecutingAssembly());
        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom == "User")
            {
                return "User=" + context.User.Identity.GetUserId();
            }

            return base.GetVaryByCustomString(context, custom);
        }
    }
}
