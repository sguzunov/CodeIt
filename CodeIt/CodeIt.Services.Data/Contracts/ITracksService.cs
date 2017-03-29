﻿using System;
using System.Collections.Generic;

using CodeIt.Data.Models;

namespace CodeIt.Services.Data.Contracts
{
    public interface ITracksService : IDataService
    {
        IEnumerable<Track> GetAll();

        IEnumerable<T> GetAll<T>();

        IEnumerable<Category> GetCategoriesByTrackId(Guid id);
    }
}
