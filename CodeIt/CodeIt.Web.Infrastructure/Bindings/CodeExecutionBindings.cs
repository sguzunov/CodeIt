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
            kernel.Bind<ISubmissionEvaluator>().To<SubmissionEvaluator>();
            kernel.Bind<ISphereEngineApiClient>().ToMethod(x =>
            {
                return new SphereEngineApiClient("ac5f8f48d0ec8e7e9df71cbebd004e56", kernel.Get<IHttpRequester>(), kernel.Get<IJsonUtils>());
            });
        }
    }
}
