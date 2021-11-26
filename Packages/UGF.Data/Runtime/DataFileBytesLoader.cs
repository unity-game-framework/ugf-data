using System;
using System.IO;
using System.Threading.Tasks;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Data.Runtime
{
    public class DataFileBytesLoader : DataLoader
    {
        protected override object OnRead(string path, IContext context)
        {
            return File.Exists(path) ? File.ReadAllBytes(path) : Array.Empty<byte>();
        }

        protected override async Task<object> OnReadAsync(string path, IContext context)
        {
            if (File.Exists(path))
            {
                await using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);

                byte[] bytes = new byte[stream.Length];

                await stream.ReadAsync(bytes, 0, bytes.Length);

                return bytes;
            }

            return Array.Empty<byte>();
        }

        protected override void OnWrite(string path, object data, IContext context)
        {
            if (data is not byte[] bytes) throw new ArgumentException("Data must be type of Byte array.");

            CreateDirectoryForFile(path);

            File.WriteAllBytes(path, bytes);
        }

        protected override async Task OnWriteAsync(string path, object data, IContext context)
        {
            if (data is not byte[] bytes) throw new ArgumentException("Data must be type of Byte array.");

            CreateDirectoryForFile(path);

            await using var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        private void CreateDirectoryForFile(string path)
        {
            string directoryPath = Path.GetDirectoryName(path);

            if (!string.IsNullOrEmpty(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
