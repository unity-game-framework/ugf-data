using System;
using System.Threading.Tasks;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public static class DataLoaderExtensions
    {
        public static bool TryRead<T>(this IDataLoader loader, string path, IContext context, out T data) where T : class
        {
            if (loader == null) throw new ArgumentNullException(nameof(loader));

            if (loader.TryRead(path, context, out object value))
            {
                data = (T)value;
                return true;
            }

            data = default;
            return false;
        }

        public static async Task<T> ReadAsync<T>(this IDataLoader loader, string path, IContext context) where T : class
        {
            return (T)await ReadAsync(loader, path, context);
        }

        public static async Task<object> ReadAsync(this IDataLoader loader, string path, IContext context)
        {
            if (loader == null) throw new ArgumentNullException(nameof(loader));

            TaskResult<object> result = await loader.TryReadAsync(path, context);

            return result ? result.Value : throw new ArgumentException($"{loader.GetType().Name} can't read from specified path: '{path}'.");
        }

        public static async Task<TaskResult<T>> TryReadAsync<T>(this IDataLoader loader, string path, IContext context) where T : class
        {
            if (loader == null) throw new ArgumentNullException(nameof(loader));

            TaskResult<object> result = await loader.TryReadAsync(path, context);

            return (T)result.Value;
        }

        public static void Write(this IDataLoader loader, string path, object data, IContext context)
        {
            if (loader == null) throw new ArgumentNullException(nameof(loader));

            if (!loader.TryWrite(path, data, context))
            {
                throw new ArgumentException($"{loader.GetType().Name} can't write at specified path: '{path}'.");
            }
        }

        public static async Task WriteAsync(this IDataLoader loader, string path, object data, IContext context)
        {
            if (loader == null) throw new ArgumentNullException(nameof(loader));

            if (!await loader.TryWriteAsync(path, data, context))
            {
                throw new ArgumentException($"{loader.GetType().Name} can't write at specified path: '{path}'.");
            }
        }
    }
}
