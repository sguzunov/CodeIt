using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using Bytes2you.Validation;
using CodeIt.Data.Contracts;

namespace CodeIt.Data
{
    public class EfRepository<TEntity> : IEfRepository<TEntity>
        where TEntity : class
    {
        private readonly ICodeItDbContext dbContext;
        private readonly IDbSet<TEntity> dbSet;

        public EfRepository(ICodeItDbContext dbContext)
        {
            Guard.WhenArgument<ICodeItDbContext>(dbContext, nameof(dbContext)).IsNull().Throw();

            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();

            if (this.dbSet == null)
            {
                throw new ArgumentException($"DbContext does not contain DbSet<{nameof(TEntity)}>");
            }
        }

        public IQueryable<TEntity> All => this.dbSet;

        public TEntity GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        private DbEntityEntry AttachIfDetached(TEntity entity)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            return entry;
        }
    }
}
