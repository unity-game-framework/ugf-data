using System;
using System.Text;
using System.Threading.Tasks;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public class DataLoaderFileText : DataLoader
    {
        public Encoding Encoding { get; }

        private readonly DataLoaderFileBytes m_loader = new DataLoaderFileBytes();

        public DataLoaderFileText() : this(Encoding.Default)
        {
        }

        public DataLoaderFileText(Encoding encoding)
        {
            Encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        }

        protected override bool OnTryRead(string path, IContext context, out object data)
        {
            if (m_loader.TryRead(path, context, out byte[] bytes))
            {
                data = Encoding.GetString(bytes);
                return true;
            }

            data = default;
            return false;
        }

        protected override async Task<TaskResult<object>> OnTryReadAsync(string path, IContext context)
        {
            TaskResult<byte[]> result = await m_loader.TryReadAsync<byte[]>(path, context);

            return result ? Encoding.GetString(result.Value) : TaskResult<object>.Empty;
        }

        protected override bool OnTryWrite(string path, object data, IContext context)
        {
            if (data is not string text) throw new ArgumentException($"Data must be type of '{typeof(string)}'.");

            byte[] bytes = Encoding.GetBytes(text);

            return m_loader.TryWrite(path, bytes, context);
        }

        protected override Task<bool> OnTryWriteAsync(string path, object data, IContext context)
        {
            if (data is not string text) throw new ArgumentException($"Data must be type of '{typeof(string)}'.");

            byte[] bytes = Encoding.GetBytes(text);

            return m_loader.TryWriteAsync(path, bytes, context);
        }
    }
}
