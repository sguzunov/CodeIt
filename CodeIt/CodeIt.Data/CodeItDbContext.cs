using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using Microsoft.AspNet.Identity.EntityFramework;

using CodeIt.Data.Models;
using CodeIt.Data.Contracts;

namespace CodeIt.Data
{
    public class CodeItDbContext : IdentityDbContext<User>, ICodeItDbContext
    {
        public CodeItDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CodeItDbContext Create()
        {
            return new CodeItDbContext();
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Challenge> Challenges { get; set; }

        public IDbSet<ChallengeDecription> ChallengeDecriptions { get; set; }

        public IDbSet<Test> Tests { get; set; }

        public IDbSet<Track> Tracks { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry<TEntity>(entity);
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Challenge - ChallengeDescription (one-to-one)
            modelBuilder.Entity<Challenge>()
                .HasOptional(x => x.ChallengeDecription)
                .WithRequired(x => x.Challenge);
        }
    }
}
