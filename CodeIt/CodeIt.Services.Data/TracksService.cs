using System.Collections.Generic;
using System.Linq;

using CodeIt.Data.Models;
using CodeIt.Services.Data.Contracts;
using CodeIt.Data.Contracts;

using Bytes2you.Validation;
using System;

namespace CodeIt.Services.Data
{
    public class TracksService : ITracksService
    {
        private readonly IEfRepository<Track> tracksRepository;

        public TracksService(IEfRepository<Track> tracksRepository)
        {
            Guard.WhenArgument(tracksRepository, nameof(tracksRepository)).IsNull().Throw();

            this.tracksRepository = tracksRepository;
        }

        public IEnumerable<Track> GetAll()
        {
            var tracks = this.tracksRepository.All.ToList();
            return tracks;
        }

        public IEnumerable<Category> GetCategoriesByTrackId(Guid id)
        {
            var categories = this.tracksRepository.GetById(id).Categories;
            return categories;
        }
    }
}
