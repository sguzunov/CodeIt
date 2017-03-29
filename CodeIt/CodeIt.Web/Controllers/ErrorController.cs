using System.Web.Mvc;

namespace CodeIt.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return this.View("Error500");
        }

        public ActionResult NotFound()
        {
            return this.View("Error404");
        }

        public ActionResult ServerError()
        {
            return this.View("Error500");
        }
    }
}