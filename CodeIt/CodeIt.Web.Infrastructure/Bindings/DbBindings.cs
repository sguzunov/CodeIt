using Ninject;

using CodeIt.Data.Contracts;
using CodeIt.Data;

namespace CodeIt.Web.Infrastructure.Bindings
{
    public class DbBindings : INinjectBinding
    {
        public void Bind(IKernel kernel)
        {
            kernel.Bind<ICodeItDbContext>().To<CodeItDbContext>();
        }
    }
}
