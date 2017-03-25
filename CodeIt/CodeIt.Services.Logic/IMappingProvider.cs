﻿using System.Collections.Generic;
using System.Linq;

namespace CodeIt.Services.Logic
{
    public interface IMappingProvider
    {
        TDestination MapObject<TSource, TDestination>(TSource source);

        IEnumerable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source);
    }
}
