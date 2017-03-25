using Bytes2you.Validation;
using CodeIt.Services.Data.Contracts;
using CodeIt.Web.Infrastructure.HtmlSanitisation;
using CodeIt.Web.ViewModels.Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeIt.Web.Controllers
{
    public class ChallengeController : BaseAuthorizationController
    {
        private readonly IChallengesService challenges;
        private readonly ISanitizer htmlSanitizer;

        public ChallengeController(IChallengesService challengesService, ISanitizer htmlSanitizer)
        {
            Guard.WhenArgument(htmlSanitizer, nameof(htmlSanitizer)).IsNull().Throw();
            Guard.WhenArgument(htmlSanitizer, nameof(htmlSanitizer)).IsNull().Throw();

            this.challenges = challengesService;
            this.htmlSanitizer = htmlSanitizer;
        }

        public ActionResult Index(string title)
        {
            var challenge = this.challenges.GetByTitle<ChallengeViewModel>(title);
            challenge.Description = this.htmlSanitizer.SanitizeContent(challenge.Description);

            return this.View(challenge);
        }
    }
}