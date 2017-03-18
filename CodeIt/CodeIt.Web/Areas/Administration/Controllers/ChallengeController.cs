using CodeIt.Web.Areas.Administration.ViewModels;
using System.Web.Mvc;
using System;

namespace CodeIt.Web.Areas.Administration.Controllers
{
    public class ChallengeController : AdministrationController
    {
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(ChallengeViewModel challenge)
        {
            throw new NotImplementedException();
        }
    }
}