using System.Web.Mvc;

using CodeIt.Web.Areas.Administration.Controllers;

namespace CodeIt.Web.Areas.Administration
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Administration";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Administration_Default",
                url: "Administration/{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = nameof(DashboardController.Index), id = UrlParameter.Optional });
        }
    }
}