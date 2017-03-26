using System.Web.Mvc;

using Bytes2you.Validation;

using CodeIt.Services.Data.Contracts;
using CodeIt.Web.Areas.Administration.ViewModels.Challenge;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CodeIt.Web.Areas.Administration.Controllers
{
    public class ChallengeGridController : AdministrationController
    {
        private readonly IChallengesService challenges;

        public ChallengeGridController(IChallengesService challengesService)
        {
            Guard.WhenArgument(challengesService, nameof(challengesService)).IsNull().Throw();

            this.challenges = challengesService;
        }

        public ActionResult Index()
        {
            var allChallenges = this.challenges.GetAll<ChallengeEditableViewModel>();
            return this.View(allChallenges);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var allChallenges = this.challenges.GetAll<ChallengeEditableViewModel>();
            return this.Json(allChallenges.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ChallengeEditableViewModel challenge)
        {
            if (challenge != null && this.ModelState.IsValid)
            {
                this.challenges.Update(challenge.Id.ToString(), challenge.Title, challenge.Language, challenge.TimeInMs, challenge.MemoryInKb);
            }

            return this.Json(new[] { challenge }.ToDataSourceResult(request, this.ModelState));
        }
    }
}