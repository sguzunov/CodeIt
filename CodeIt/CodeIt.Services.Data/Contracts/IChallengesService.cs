using CodeIt.Data.Models;
using System.Collections.Generic;

namespace CodeIt.Services.Data.Contracts
{
    public interface IChallengesService : IDataService
    {
        Challenge Create(string title, string description, string categoryId, Language language, int timeInMs, int memoryInKb, IEnumerable<Test> tests);

        Challenge CreateWithFileDescription(
            string title,
            string description,
            string categoryId,
            Language language,
            int timeInMs,
            int memoryInKb,
            IEnumerable<Test> tests,
            string fileOriginalName,
            string fileExtension,
            string filePath);

        IEnumerable<TDestination> GetAll<TDestination>();

        void Update(string id, string title, Language language, int timeInMs, int memoryInKb);
    }
}
