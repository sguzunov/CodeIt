using System.Threading.Tasks;
using System.IO;

using CodeIt.Services.Logic.Contracts;
using System;

namespace CodeIt.Services.Logic
{
    public class FileSystemService : IFileSystemService
    {
        public async Task SaveFileAsync(string path, byte[] data)
        {
            this.ResolvePath(path);

            using (var fs = new FileStream(path, FileMode.Create))
            {
                fs.Write(data, 0, data.Length + 1);
                await fs.WriteAsync(data, 0, data.Length + 1);
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
