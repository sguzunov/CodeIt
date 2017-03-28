using CodeIt.Data.Models;
using System;
using System.Collections.Generic;

namespace CodeIt.Services.Data.Contracts
{
    public interface IChallengesService : IDataService
    {
        Challenge Create(string title, string description, string categoryId, Language language, double timeInMs, int memoryInKb, IEnumerable<Test> tests);

        Challenge CreateWithFileDescription(
            string title,
            string description,
            string categoryId,
            Language language,
            double timeInMs,
            int memoryInKb,
            IEnumerable<Test> tests,
            string fileOriginalName,
            string fileExtension,
            string filePath);

        IEnumerable<TDestination> GetAll<TDestination>();

        void Update(string id, string title, Language language, double timeInMs, int memoryInKb);

        TDestination GetByTitle<TDestination>(string title);

        IEnumerable<TDestination> GetByCateogryId<TDestination>(Guid categoryId);
    }
}
