using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CodeIt.CodeExecution.Contracts;
using CodeIt.CodeExecution.Models;
using CodeIt.Data.Models;

namespace CodeIt.CodeExecution
{
    public class SubmissionEvaluator : ISubmissionEvaluator
    {
        private readonly ISphereEngineApiClient engine;

        public SubmissionEvaluator(ISphereEngineApiClient engine)
        {
            this.engine = engine;
        }

        public async Task<IEnumerable<SubmissionIdentifier>> ExecuteTests(string sourceCode, Language language, IEnumerable<string> inputs)
        {
            var identifiers = new List<SubmissionIdentifier>();
            foreach (var testInput in inputs)
            {
                var option = new SubmissionOptions
                {
                    Input = testInput,
                    Language = language,
                    SourceCode = sourceCode
                };

                identifiers.Add(await this.engine.Submit(option));
            }

            return identifiers;
        }

        public async Task<IList<SubmissionExecutionResult>> GetResults(IList<SubmissionIdentifier> identifiers)
        {
            var result = new List<SubmissionExecutionResult>();
            foreach (var identity in identifiers)
            {
                result.Add(await this.engine.GetSubmissionResult(identity.Id));
            }

            return result;
        }
    }
}
