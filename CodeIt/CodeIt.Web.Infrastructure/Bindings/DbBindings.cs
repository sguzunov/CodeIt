using CodeIt.Data;
using CodeIt.Data.Contracts;

using Ninject;
using Ninject.Web.Common;

namespace CodeIt.Web.Infrastructure.Bindings
{
    public class DbBindings : INinjectBinding
    {
        public void Bind(IKernel kernel)
        {
            kernel.Bind<ICodeItDbContext>().To<CodeItDbContext>().InRequestScope();
            kernel.Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>));
            kernel.Bind<IEfData>().To<EfData>();
        }
    }
}
