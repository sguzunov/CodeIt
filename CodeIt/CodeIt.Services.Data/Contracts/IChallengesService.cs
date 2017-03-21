using CodeIt.Data.Models;
using System.Collections.Generic;

namespace CodeIt.Services.Data.Contracts
{
    public interface IChallengesService : IDataService
    {
        Challenge Create(string title, string description, string categoryId, Language language, double timeInMs, double memoryInMb, IEnumerable<Test> tests);

        Challenge CreateWithFileDescription(
            string title,
            string description,
            string categoryId,
            Language language,
            double timeInMs,
            double memoryInMb,
            IEnumerable<Test> tests,
            string fileOriginalName,
            string fileExtension,
            string filePath);
    }
}
