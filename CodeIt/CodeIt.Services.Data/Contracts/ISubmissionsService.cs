using CodeIt.Data.Models;
using System;
using System.Collections.Generic;

namespace CodeIt.Services.Data.Contracts
{
    public interface ISubmissionsService : IDataService
    {
        Submission Create(User creator, Guid challengeId, string sourceCode);

        IEnumerable<TDestination> GetUserSubmissionByChallenge<TDestination>(string userId, string challengeTitle);
    }
}
