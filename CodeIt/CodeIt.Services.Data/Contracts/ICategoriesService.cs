using System.Collections.Generic;

namespace CodeIt.Services.Data.Contracts
{
    public interface ICategoriesService : IDataService
    {
        IEnumerable<TDestination> GetByTrack<TDestination>(string trackName);
    }
}
