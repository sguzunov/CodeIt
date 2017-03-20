using CodeIt.Data;
using CodeIt.Data.Contracts;

using Ninject;

namespace CodeIt.Web.Infrastructure.Bindings
{
    public class DbBindings : INinjectBinding
    {
        public void Bind(IKernel kernel)
        {
            kernel.Bind<ICodeItDbContext>().To<CodeItDbContext>();
            kernel.Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>));
            kernel.Bind<IEfData>().To<EfData>();
        }
    }
}
