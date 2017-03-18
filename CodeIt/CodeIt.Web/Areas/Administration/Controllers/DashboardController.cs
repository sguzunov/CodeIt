using System.Web.Mvc;

namespace CodeIt.Web.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationController
    {
        public ActionResult Index()
        {
            this.ViewBag.Message = "Hore Some statistics!";

            return this.View();
        }
    }
}