using CodeIt.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeIt.Data.Models;
using CodeIt.Data.Contracts;
using CodeIt.CodeExecution.Models;

namespace CodeIt.Services.Data
{
    public class TestResultsService : ITestResultsService
    {
        private readonly IEfRepository<TestResult> testResultsRepository;
        private readonly IEfData efData;

        public TestResultsService(IEfRepository<TestResult> testResultsRepository, IEfData efData)
        {
            this.testResultsRepository = testResultsRepository;
            this.efData = efData;
        }

        public void CreateTestResults(Submission submission, IList<Test> tests, IList<int> identifiers)
        {
            for (int i = 0; i < tests.Count; i++)
            {
                var test = tests[i];
                var identifier = identifiers[i];

                using (this.efData)
                {
                    var testResult = new TestResult
                    {
                        Id = Guid.NewGuid(),
                        ApiIdentifier = new SphereApiTestIdentifier { Identifier = identifier },
                        IsEvaluated = false,
                        SubmissionId = submission.Id,
                        Submission = submission,
                        TestId = test.Id,
                        Test = test,
                    };

                    this.testResultsRepository.Add(testResult);
                    this.efData.Commit();
                }
            }
        }

        public IEnumerable<TestResult> GetBySubmission(Guid submissionId)
        {
            return this.testResultsRepository.All.Where(x => x.SubmissionId == submissionId).ToList();
        }

        public void UpdateTests(IList<TestResult> tests, IList<SubmissionExecutionResult> executionResults)
        {
            for (int i = 0; i < executionResults.Count; i++)
            {
                var execResult = executionResults[i];
                var testResult = tests[i];

                testResult.CompileError = execResult.CompileError;
                testResult.RuntimeException = execResult.RuntimeException;
                testResult.IsEvaluated = true;

                if (testResult.Test.Challenge.TimeInMs > execResult.TimeExecution)
                {
                    testResult.TimeLimited = true;
                }

                testResult.IsPassed = testResult.Test.Output == execResult.Output.Trim();

                this.testResultsRepository.Update(testResult);
                this.efData.Commit();
            }
        }
    }
}
