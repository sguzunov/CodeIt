using CodeIt.CodeExecution.Models;
using CodeIt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIt.CodeExecution.Contracts
{
    public interface IExecutionService
    {
        Task<IEnumerable<SubmissionIdentifier>> EvaluateTests(string sourceCode, Language lang, IEnumerable<string> inputs);

        Task<IEnumerable<SubmissionExecutionResult>> GetExecutionResults(IEnumerable<int> inputs);
    }
}
