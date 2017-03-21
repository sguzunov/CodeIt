using System;
using System.Threading.Tasks;

namespace CodeIt.Data.Contracts
{
    public interface IEfData : IDisposable
    {
        int Commit();

        Task<int> CommitAsync();
    }
}
