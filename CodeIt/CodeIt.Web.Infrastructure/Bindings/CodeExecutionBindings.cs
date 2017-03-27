using Ninject;
using CodeIt.CodeExecution.Helpers.Contracts;
using CodeIt.CodeExecution.Helpers;
using CodeIt.CodeExecution.Contracts;
using CodeIt.CodeExecution;

namespace CodeIt.Web.Infrastructure.Bindings
{
    public class CodeExecutionBindings : INinjectBinding
    {
        public void Bind(IKernel kernel)
        {
            kernel.Bind<IHttpRequester>().To<CodeExecution.Helpers.HttpRequester>();
            kernel.Bind<IJsonUtils>().To<JsonUtils>();

            kernel.Bind<IExecutionService>().To<ExecutionService>();
            kernel.Bind<ISphereEngineApiClient>().To<SphereEngineApiClient>();
            kernel.Bind<ISubmissionEvaluator>().To<SubmissionEvaluator>();
        }
    }
}
