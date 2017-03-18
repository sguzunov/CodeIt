using System.Web.Mvc;

namespace CodeIt.Web.Areas.Administration
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Administration";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "AdministrationDefault",
                url: "Administration/{controller}/{action}/id",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}