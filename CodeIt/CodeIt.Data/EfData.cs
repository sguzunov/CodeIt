using System.Threading.Tasks;

using Bytes2you.Validation;

using CodeIt.Data.Contracts;

namespace CodeIt.Data
{
    public class EfData : IEfData
    {
        private readonly ICodeItDbContext dbContext;

        public EfData(ICodeItDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, nameof(dbContext)).IsNull().Throw();

            this.dbContext = dbContext;
        }

        public int Commit()
        {
            int changes = this.dbContext.SaveChanges();
            return changes;
        }

        public async Task<int> CommitAsync()
        {
            int changes = await this.dbContext.SaveChangesAsync();
            return changes;
        }

        public void Dispose()
        {
        }
    }
}
