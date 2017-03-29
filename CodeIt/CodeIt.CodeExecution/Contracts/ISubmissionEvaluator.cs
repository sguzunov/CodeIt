using System.Collections.Generic;
using System.Threading.Tasks;

using CodeIt.CodeExecution.Models;
using CodeIt.Data.Models;

namespace CodeIt.CodeExecution.Contracts
{
    public interface ISubmissionEvaluator
    {
        Task<IEnumerable<SubmissionIdentifier>> ExecuteTests(string sourceCode, Language language, IEnumerable<string> inputs);

        Task<IList<SubmissionExecutionResult>> GetResults(IList<SubmissionIdentifier> identifiers);
    }
}
