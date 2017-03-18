using System.Web.Mvc;

using CodeIt.Common;

namespace CodeIt.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : Controller
    {
    }
}