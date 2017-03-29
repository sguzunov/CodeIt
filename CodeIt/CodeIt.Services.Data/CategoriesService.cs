using Bytes2you.Validation;
using CodeIt.Data.Contracts;
using CodeIt.Data.Models;
using CodeIt.Services.Data.Contracts;
using CodeIt.Services.Logic;
using System.Collections.Generic;
using System.Linq;

namespace CodeIt.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IEfRepository<Category> categoriesRepository;
        private readonly IMappingProvider mapper;

        public CategoriesService(IEfRepository<Category> categoriesRepository, IMappingProvider mapper)
        {
            Guard.WhenArgument(categoriesRepository, nameof(categoriesRepository)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.categoriesRepository = categoriesRepository;
            this.mapper = mapper;
        }

        public IEnumerable<TDestination> GetByTrack<TDestination>(string trackName)
        {
            var categories = this.mapper.ProjectTo<Category, TDestination>(
                this.categoriesRepository
                .All
                .Where(x => x.Track.Name == trackName));

            return categories;
        }
    }
}
