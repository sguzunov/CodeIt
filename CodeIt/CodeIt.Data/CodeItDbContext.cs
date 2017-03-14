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

        public IDbSet<User> Users { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public new int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
