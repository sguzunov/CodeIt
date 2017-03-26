using Ninject;
using CodeIt.Web.Infrastructure.HtmlSanitisation;
using CodeIt.Services.Logic;
using CodeIt.Web.Infrastructure.FileSystem;
using CodeIt.Web.Auth.Contracts;
using CodeIt.Web.Auth;
using CodeIt.Services.Logic.Contracts;

namespace CodeIt.Web.Infrastructure.Bindings
{
    public class CommonBindings : INinjectBinding
    {
        public void Bind(IKernel kernel)
        {
            kernel.Bind<ISanitizer>().To<HtmlContentSanitizer>();
            kernel.Bind<IFileUnits>().To<FileUnits>();
            kernel.Bind<IFileSystemService>().To<FileSystemService>();
            kernel.Bind<IMappingProvider>().To<MappingProvider>();
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
            kernel.Bind<ITimeProvider>().To<TimeProvider>();
        }
    }
}
