[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CodeIt.Web.Config.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(CodeIt.Web.Config.NinjectConfig), "Stop")]

namespace CodeIt.Web.Config
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web;

    using CodeIt.Web.Auth;
    using CodeIt.Web.Auth.Contracts;
    using CodeIt.Web.Infrastructure.Bindings;

    using Microsoft.Owin;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using AutoMapper;

    using CodeIt.Web.Infrastructure.Mapping;
    using CodeIt.Services.Logic;
    using CodeIt.Services.Logic.Contracts;
    using CodeIt.Data.Contracts;
    using CodeIt.Data;
    using CodeIt.Web.Infrastructure.FileSystem;

    public static class NinjectConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var registries =
                Assembly.Load("CodeIt.Web.Infrastructure")
                    .GetExportedTypes()
                    .Where(t => t.IsClass && typeof(INinjectBinding).IsAssignableFrom(t));

            foreach (var registry in registries)
            {
                var registryInstance = (INinjectBinding)Activator.CreateInstance(registry);
                registryInstance.Bind(kernel);
            }

            kernel.Bind<IFileUnits>().To<FileUnits>();
            kernel.Bind<IFileSystemService>().To<FileSystemService>();
            kernel.Bind<IMappingProvider>().To<MappingProvider>();
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
            kernel.Bind<IOwinContext>().ToMethod(x => HttpContext.Current.GetOwinContext())
                .WhenInjectedInto(typeof(IAuthenticationService));
        }
    }
}
