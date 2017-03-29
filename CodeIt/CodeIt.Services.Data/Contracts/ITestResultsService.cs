using CodeIt.CodeExecution.Models;
using CodeIt.Data.Models;
using System;
using System.Collections.Generic;

namespace CodeIt.Services.Data.Contracts
{
    public interface ITestResultsService : IDataService
    {
        void CreateTestResults(Submission submission, IList<Test> tests, IList<int> identifiers);

        IEnumerable<TestResult> GetBySubmission(Guid submissionId);

        void UpdateTests(IList<TestResult> tests, IList<SubmissionExecutionResult> executionResults);
    }
}
