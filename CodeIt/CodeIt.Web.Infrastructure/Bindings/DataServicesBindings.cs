using CodeIt.Services.Data.Contracts;

using Ninject;
using Ninject.Extensions.Conventions;

namespace CodeIt.Web.Infrastructure.Bindings
{
    public class DataServicesBindings : INinjectBinding
    {
        public void Bind(IKernel kernel)
        {
            kernel.Bind(x =>
            {
                x.FromAssemblyContaining<IDataService>()
                .SelectAllClasses()
                .BindDefaultInterface()
                .Configure(b => b.InScope(s => s.Request));
            });
        }
    }
}
