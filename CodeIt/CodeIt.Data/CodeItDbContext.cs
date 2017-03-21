using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

using CodeIt.Data.Contracts;
using CodeIt.Data.Models;

using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeIt.Data
{
    public class CodeItDbContext : IdentityDbContext<User>, ICodeItDbContext
    {
        public CodeItDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Challenge> Challenges { get; set; }

        public IDbSet<FileDecription> ChallengeDecriptions { get; set; }

        public IDbSet<Test> Tests { get; set; }

        public IDbSet<Track> Tracks { get; set; }

        public static CodeItDbContext Create()
        {
            return new CodeItDbContext();
        }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class
        {
            return base.Entry<TEntity>(entity);
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async new Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Challenge - ChallengeDescription (one-to-one)
            modelBuilder.Entity<Challenge>()
                .HasOptional(x => x.FileDecription)
                .WithRequired(x => x.Challenge);
        }
    }
}
