using Bytes2you.Validation;
using CodeIt.Services.Data.Contracts;
using CodeIt.Web.Infrastructure.HtmlSanitisation;
using CodeIt.Web.ViewModels.Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CodeIt.Web.Controllers
{
    public class ChallengeController : BaseAuthorizationController
    {
        private readonly IChallengesService challenges;
        private readonly ISubmissionsService submissions;
        private readonly ISanitizer htmlSanitizer;

        public ChallengeController(
            IUsersService usersService,
            IChallengesService challengesService,
            ISubmissionsService submissionsService,
            ISanitizer htmlSanitizer)
            : base(usersService)
        {
            Guard.WhenArgument(htmlSanitizer, nameof(htmlSanitizer)).IsNull().Throw();
            Guard.WhenArgument(submissionsService, nameof(submissionsService)).IsNull().Throw();
            Guard.WhenArgument(htmlSanitizer, nameof(htmlSanitizer)).IsNull().Throw();

            this.challenges = challengesService;
            this.submissions = submissionsService;
            this.htmlSanitizer = htmlSanitizer;
        }

        public ActionResult Index(string title)
        {
            var challenge = this.challenges.GetByTitle<ChallengeViewModel>(title);
            challenge.Description = this.htmlSanitizer.SanitizeContent(challenge.Description);

            return this.View(challenge);
        }

        [HttpPost]
        public ActionResult Submit(SubmissionViewModel submission)
        {
            if (!this.ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            this.submissions.Create(this.LoggedUser, Guid.Parse(submission.ChallengeId), submission.SourceCode);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}