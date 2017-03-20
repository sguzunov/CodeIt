using AutoMapper;

namespace CodeIt.Web.Infrastructure.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfigurationProvider configuration);
    }
}
