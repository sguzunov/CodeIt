using System;
using System.Collections.Generic;

using CodeIt.Data.Models;

namespace CodeIt.Services.Data.Contracts
{
    public interface ITracksService : IDataService
    {
        IEnumerable<Track> GetAll();

        IEnumerable<Category> GetCategoriesByTrackId(Guid id);
    }
}
