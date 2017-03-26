using CodeIt.Data.Models;
using CodeIt.Web.Infrastructure.Mapping;
using AutoMapper;

namespace CodeIt.Web.ViewModels.Home
{
    public class TrackViewModel : IMapFrom<Track>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string LogoPath { get; set; }

        public int NumberOfCateogries { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Track, TrackViewModel>()
                .ForMember(x => x.LogoPath, opt => opt.MapFrom(p => p.Logo.FileSystemPath + p.Logo.FileName + "." + p.Logo.FileExtension))
                .ForMember(x => x.NumberOfCateogries, opt => opt.MapFrom(p => p.Categories.Count));
        }
    }
}