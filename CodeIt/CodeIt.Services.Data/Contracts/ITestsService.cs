using System.Collections.Generic;

namespace CodeIt.Services.Data.Contracts
{
    public interface ITestsService
    {
        IEnumerable<TDestination> GetByChallenge<TDestination>(string challengeId);

        void DeleteById(string id);

        void Update(string input, string output);
    }
}
