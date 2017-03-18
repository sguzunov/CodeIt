using System.Web.Mvc;

namespace CodeIt.Web.Areas.Administration
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Admin",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" });
        }
    }
}