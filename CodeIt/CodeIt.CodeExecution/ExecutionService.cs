using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CodeIt.CodeExecution.Contracts;
using CodeIt.CodeExecution.Models;
using CodeIt.Data.Models;
using System.Linq;

namespace CodeIt.CodeExecution
{
    public class ExecutionService : IExecutionService
    {
        private readonly ISubmissionEvaluator evaluator;

        public ExecutionService(ISubmissionEvaluator evaluator)
        {
            this.evaluator = evaluator;
        }

        public async Task<IEnumerable<SubmissionIdentifier>> EvaluateTests(string sourceCode, Language lang, IEnumerable<string> inputs)
        {
            return await this.evaluator.ExecuteTests(sourceCode, lang, inputs);
        }

        public async Task<IEnumerable<SubmissionExecutionResult>> GetExecutionResults(IEnumerable<int> ids)
        {
            var identifiers = ids.Select(x => new SubmissionIdentifier { Id = x }).ToList();
            var results = await this.evaluator.GetResults(identifiers);
            return results;
        }
    }
}
