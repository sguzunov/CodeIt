using AutoMapper;

using CodeIt.Services.Logic;
using CodeIt.Web.Infrastructure.Mapping;

using Ninject;

namespace CodeIt.Web.Infrastructure.Bindings
{
    public class AutomapperBindings : INinjectBinding
    {
        public void Bind(IKernel kernel)
        {
            kernel.Bind<IConfigurationProvider>().ToMethod(x => AutoMapperConfig.Configuration).WhenInjectedInto(typeof(MappingProvider));
        }
    }
}
