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
                url: "Administration/Dashboard/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = nameof(HomeController.Index), id = UrlParameter.Optional });
        }
    }
}