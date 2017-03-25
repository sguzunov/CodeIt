using System.Web.Mvc;

using CodeIt.Data.Models;

namespace CodeIt.Web.Controllers
{
    public class BaseAuthorizationController : Controller
    {
        protected User LoggedUser { get; set; }
    }
}