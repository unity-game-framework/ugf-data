using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Data.Runtime
{
    public class DataLoaderFileText : DataLoader
    {
        public Encoding Encoding { get; }

        public DataLoaderFileText() : this(Encoding.Default)
        {
        }

        public DataLoaderFileText(Encoding encoding)
        {
            Encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        }

        protected override object OnRead(string path, IContext context)
        {
            return File.Exists(path) ? File.ReadAllText(path, Encoding) : string.Empty;
        }

        protected override async Task<object> OnReadAsync(string path, IContext context)
        {
            if (File.Exists(path))
            {
                await using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);

                byte[] bytes = new byte[stream.Length];

                await stream.ReadAsync(bytes, 0, bytes.Length);

                return Encoding.GetString(bytes);
            }

            return string.Empty;
        }

        protected override void OnWrite(string path, object data, IContext context)
        {
            if (data is not string content) throw new ArgumentException("Data must be type of String.");

            CreateDirectoryForFile(path);

            File.WriteAllText(path, content, Encoding);
        }

        protected override async Task OnWriteAsync(string path, object data, IContext context)
        {
            if (data is not string content) throw new ArgumentException("Data must be type of String.");

            CreateDirectoryForFile(path);

            byte[] bytes = Encoding.GetBytes(content);

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
