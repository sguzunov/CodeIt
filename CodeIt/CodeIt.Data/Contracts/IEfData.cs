using System.Threading.Tasks;

namespace CodeIt.Data.Contracts
{
    public interface IEfData
    {
        int Commit();

        Task<int> CommitAsync();
    }
}
