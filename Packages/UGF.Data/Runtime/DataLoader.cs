using System;
using System.Threading.Tasks;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public abstract class DataLoader : IDataLoader
    {
        public bool TryRead(string path, IContext context, out object data)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (context == null) throw new ArgumentNullException(nameof(context));

            return OnTryRead(path, context, out data);
        }

        public Task<TaskResult<object>> TryReadAsync(string path, IContext context)
        {
            return OnTryReadAsync(path, context);
        }

        public bool TryWrite(string path, object data, IContext context)
        {
            return OnTryWrite(path, data, context);
        }

        public Task<bool> TryWriteAsync(string path, object data, IContext context)
        {
            return OnTryWriteAsync(path, data, context);
        }

        protected abstract bool OnTryRead(string path, IContext context, out object data);
        protected abstract Task<TaskResult<object>> OnTryReadAsync(string path, IContext context);
        protected abstract bool OnTryWrite(string path, object data, IContext context);
        protected abstract Task<bool> OnTryWriteAsync(string path, object data, IContext context);
    }
}
