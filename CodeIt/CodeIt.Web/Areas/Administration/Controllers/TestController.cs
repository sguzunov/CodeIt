using Bytes2you.Validation;
using CodeIt.Services.Data.Contracts;
using CodeIt.Web.Areas.Administration.ViewModels;
using System;
using System.Web.Mvc;

namespace CodeIt.Web.Areas.Administration.Controllers
{
    public class TestController : AdministrationController
    {
        private readonly ITestsService tests;

        public TestController(ITestsService tests)
        {
            Guard.WhenArgument(tests, nameof(tests)).IsNull().Throw();

            this.tests = tests;
        }

        public ActionResult ByChallengeId(string id)
        {
            var tests = this.tests.GetByChallenge<ChallengeTestAdministrationViewModel>(id);
            return this.View(tests);
        }

        public ActionResult Update(ChallengeTestAdministrationViewModel challenge)
        {
            //this.tests.Update()
            throw new NotImplementedException();
        }

        public ActionResult Delete(string id, string returnUrlId)
        {
            this.tests.DeleteById(id);

            return this.RedirectToAction(nameof(TestController.ByChallengeId), new { id = returnUrlId });
        }
    }
}