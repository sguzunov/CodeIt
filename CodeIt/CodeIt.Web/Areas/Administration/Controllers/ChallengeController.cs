using CodeIt.Web.Areas.Administration.ViewModels;
using System.Web.Mvc;
using System;
using System.Collections.Generic;

namespace CodeIt.Web.Areas.Administration.Controllers
{
    public class ChallengeController : AdministrationController
    {
        public ChallengeController()
        {

        }

        [HttpGet]
        public ActionResult Create()
        {
            var vModel = new ChallengeAdministrationViewModel()
            {
                Tracks = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem { Value = "1", Text = "Strings" },
                    new SelectListItem { Value = "2", Text = "Loops" },
                    new SelectListItem { Value = "3", Text = "Fors" },
                }, "Value", "Text")
            };

            return this.View(vModel);
        }

        [HttpPost]
        public ActionResult Create(ChallengeAdministrationViewModel challenge)
        {
            throw new NotImplementedException();
        }
    }
}