using CodeIt.Data.Models;
using System.Collections.Generic;

namespace CodeIt.Services.Data.Contracts
{
    public interface ITestResultsService : IDataService
    {
        void CreateTestResults(Submission submission, IList<Test> tests, IList<int> identifiers);
    }
}
