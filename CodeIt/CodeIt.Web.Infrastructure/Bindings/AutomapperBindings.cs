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
            kernel.Bind<IMapper>().ToMethod(x => AutoMapperConfig.Configuration.CreateMapper()).WhenInjectedInto(typeof(MappingProvider));
        }
    }
}
