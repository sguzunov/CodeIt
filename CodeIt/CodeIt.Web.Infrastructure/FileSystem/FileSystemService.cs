using System.IO;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace CodeIt.Web.Infrastructure.FileSystem
{
    public class FileSystemService : IFileSystemService
    {
        public async Task SaveFileAsync(string path, byte[] data)
        {
            this.ResolvePath(path);
            path = HostingEnvironment.MapPath(path);
            using (var fs = new FileStream(path, FileMode.Create))
            {
                fs.Write(data, 0, data.Length);
                await fs.WriteAsync(data, 0, data.Length);
            }
        }

        public async Task SaveFileAsync(string path, Stream stream)
        {
            byte[] bytesInStream = new byte[stream.Length];
            stream.Read(bytesInStream, 0, bytesInStream.Length);
            await this.SaveFileAsync(path, bytesInStream);
        }

        private void ResolvePath(string path)
        {
            var dir = Directory.Exists(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
