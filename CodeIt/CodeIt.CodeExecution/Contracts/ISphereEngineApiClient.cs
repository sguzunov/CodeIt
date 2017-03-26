using System.Threading.Tasks;

using CodeIt.CodeExecution.Models;

namespace CodeIt.CodeExecution.Contracts
{
    public interface ISphereEngineApiClient
    {
        Task<SubmissionIdentifyResult> Submit(SubmissionOptions options);

        Task<CodeExecutionResult> GetSubmissionResult(int id);
    }
}
