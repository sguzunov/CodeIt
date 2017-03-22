using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;

namespace CodeIt.Services.Logic
{
    public class MappingProvider : IMappingProvider
    {
        private readonly IMapper mapper;
        private readonly IConfigurationProvider config;

        public MappingProvider(IMapper mapper, IConfigurationProvider config)
        {
            this.mapper = mapper;
            this.config = config;
        }

        public IEnumerable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source)
        {
            return source.ProjectTo<TDestination>(this.config).ToList();
        }

        public TDestination MapObject<TSource, TDestination>(TSource source)
        {
            return this.mapper.Map<TSource, TDestination>(source);
        }
    }
}
