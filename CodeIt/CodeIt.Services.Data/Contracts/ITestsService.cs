using System;
using System.Collections.Generic;

namespace CodeIt.Services.Data.Contracts
{
    public interface ITestsService
    {
        IEnumerable<TDestination> GetByChallenge<TDestination>(Guid challengeId);

        void DeleteById(Guid id);

        void Update(Guid id, string input, string output);
    }
}
