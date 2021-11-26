using System;
using System.Threading.Tasks;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Data.Runtime
{
    public abstract class DataLoader : IDataLoader
    {
        public T Read<T>(string path, IContext context) where T : class
        {
            return (T)Read(path, context);
        }

        public object Read(string path, IContext context)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));

            return OnRead(path, context);
        }

        public async Task<T> ReadAsync<T>(string path, IContext context) where T : class
        {
            return (T)await ReadAsync(path, context);
        }

        public Task<object> ReadAsync(string path, IContext context)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));

            return OnReadAsync(path, context);
        }

        public void Write<T>(string path, T data, IContext context) where T : class
        {
            Write(path, (object)data, context);
        }

        public void Write(string path, object data, IContext context)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (data == null) throw new ArgumentNullException(nameof(data));

            OnWrite(path, data, context);
        }

        public async Task WriteAsync<T>(string path, T data, IContext context) where T : class
        {
            await WriteAsync(path, (object)data, context);
        }

        public Task WriteAsync(string path, object data, IContext context)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (data == null) throw new ArgumentNullException(nameof(data));

            return OnWriteAsync(path, data, context);
        }

        protected abstract object OnRead(string path, IContext context);
        protected abstract Task<object> OnReadAsync(string path, IContext context);
        protected abstract void OnWrite(string path, object data, IContext context);
        protected abstract Task OnWriteAsync(string path, object data, IContext context);
    }
}
