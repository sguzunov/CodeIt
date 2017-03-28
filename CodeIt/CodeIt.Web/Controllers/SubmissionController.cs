using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeIt.Services.Data.Contracts;
using System.Web.Mvc;
using CodeIt.Web.ViewModels.Challenge;
using System.Net;
using CodeIt.CodeExecution.Contracts;
using System.Threading.Tasks;

namespace CodeIt.Web.Controllers
{
    public class SubmissionController : BaseAuthorizationController
    {
        private readonly ISubmissionsService submissions;
        private readonly IExecutionService executionService;
        private readonly ITestsService tests;
        private readonly ITestResultsService testResults;

        public SubmissionController(
            ISubmissionsService submissions,
            IExecutionService executionService,
            ITestsService tests,
            IUsersService users,
            ITestResultsService testResults)
            : base(users)
        {
            this.submissions = submissions;
            this.executionService = executionService;
            this.tests = tests;
            this.testResults = testResults;
        }

        [HttpPost]
        public async Task<ActionResult> Submit(SubmissionCreateViewModel submission)
        {
            if (!this.ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dbSubmission = this.submissions.Create(this.LoggedUser, Guid.Parse(submission.ChallengeId), submission.SourceCode);

            // Code Execution
            var tests = this.tests.GetByChallenge(dbSubmission.ChallengeId);
            var testsResultIdentifiers = await this.executionService.EvaluateTests(dbSubmission.SourceCode, dbSubmission.Challenge.Language, tests.Select(x => x.Input));

            this.testResults.CreateTestResults(dbSubmission, tests.ToList(), testsResultIdentifiers.Select(x => x.Id).ToList());

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpGet]
        public ActionResult SubmissionsByChallenge(string title)
        {
            var result = this.submissions.GetUserSubmissionByChallenge<SubmissionListViewModel>(this.LoggedUser.Id, title);

            return this.PartialView("~/Views/Challenge/Submissions.cshtml", result);
        }

        public async Task<ActionResult> RunSubmissionTests(string id)
        {
            var results = this.testResults.GetBySubmission(Guid.Parse(id));
            var apiIds = results.Select(x => x.ApiIdentifier.Identifier).ToList();
            var executionResults = await this.executionService.GetExecutionResults(apiIds);
            this.testResults.UpdateTests(results.ToList(), executionResults.ToList());
            this.submissions.RunSubmission(Guid.Parse(id));

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}