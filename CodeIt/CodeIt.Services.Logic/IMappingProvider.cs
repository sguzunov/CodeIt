namespace CodeIt.Services.Logic
{
    public interface IMappingProvider
    {
        void MapObject<TSource, TDestination>();
    }
}
