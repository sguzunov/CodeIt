using System.IO;
using System.Threading.Tasks;

namespace CodeIt.Web.Infrastructure.FileSystem
{
    public interface IFileSystemService
    {
        Task SaveFileAsync(string path, byte[] data);

        Task SaveFileAsync(string path, Stream stream);
    }
}
