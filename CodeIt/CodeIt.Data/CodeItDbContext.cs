using System;
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

        //public IDbSet<User> Users { get; set; }

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
    }
}
