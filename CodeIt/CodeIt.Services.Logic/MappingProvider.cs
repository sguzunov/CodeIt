using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;

namespace CodeIt.Services.Logic
{
    public class MappingProvider : IMappingProvider
    {
        private readonly IMapper mapper;

        public MappingProvider(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IEnumerable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source)
        {
            return source.ProjectTo<TDestination>().ToList();
        }

        TDestination IMappingProvider.MapObject<TSource, TDestination>(TSource source)
        {
            return this.mapper.Map<TSource, TDestination>(source);
        }
    }
}
