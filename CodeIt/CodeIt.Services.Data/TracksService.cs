using System.Collections.Generic;
using System.Linq;

using CodeIt.Data.Models;
using CodeIt.Services.Data.Contracts;
using CodeIt.Data.Contracts;

using Bytes2you.Validation;
using System;
using CodeIt.Services.Logic;

namespace CodeIt.Services.Data
{
    public class TracksService : ITracksService
    {
        private readonly IEfRepository<Track> tracksRepository;
        private readonly IMappingProvider mapper;

        public TracksService(IEfRepository<Track> tracksRepository, IMappingProvider mapper)
        {
            Guard.WhenArgument(tracksRepository, nameof(tracksRepository)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.tracksRepository = tracksRepository;
            this.mapper = mapper;
        }

        public IEnumerable<Track> GetAll()
        {
            var tracks = this.tracksRepository.All.ToList();
            return tracks;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var tracks = this.mapper.ProjectTo<Track, T>(this.tracksRepository.All).ToList();
            return tracks;
        }

        public IEnumerable<Category> GetCategoriesByTrackId(Guid id)
        {
            var categories = this.tracksRepository.GetById(id).Categories;
            return categories;
        }
    }
}
