using System.Threading.Tasks;

using CodeIt.CodeExecution.Models;

namespace CodeIt.CodeExecution.Contracts
{
    public interface ISphereEngineApiClient
    {
        Task<SubmissionIdentifier> Submit(SubmissionOptions options);

        Task<SubmissionExecutionResult> GetSubmissionResult(int id);
    }
}
