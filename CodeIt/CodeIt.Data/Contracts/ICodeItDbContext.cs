using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using CodeIt.Data.Models;

namespace CodeIt.Data.Contracts
{
    public interface ICodeItDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Challenge> Challenges { get; set; }

        IDbSet<ChallengeDecription> ChallengeDecriptions { get; set; }

        IDbSet<Test> Tests { get; set; }

        IDbSet<Track> Tracks { get; set; }

        IDbSet<T> Set<T>()
            where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        int SaveChanges();
    }
}
