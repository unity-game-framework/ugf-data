using System;
using System.Threading.Tasks;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public static class DataLoaderControllerExtensions
    {
        public static T Read<T>(this IDataLoaderController controller, string path) where T : class
        {
            return (T)Read(controller, path, typeof(T));
        }

        public static object Read(this IDataLoaderController controller, string path, Type targetType)
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            return controller.TryRead(path, targetType, out object target) ? target : throw new ArgumentException($"{controller.GetType().Name} loader can't read from specified path: '{path}'.");
        }

        public static bool TryRead<T>(this IDataLoaderController controller, string path, out T target) where T : class
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            if (controller.TryRead(path, typeof(T), out object value))
            {
                target = (T)value;
                return true;
            }

            target = default;
            return false;
        }

        public static async Task<T> ReadAsync<T>(this IDataLoaderController controller, string path, Type targetType) where T : class
        {
            return (T)await ReadAsync(controller, path, targetType);
        }

        public static async Task<object> ReadAsync(this IDataLoaderController controller, string path, Type targetType)
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            TaskResult<object> result = await controller.TryReadAsync(path, targetType);

            return result ? result.Value : throw new ArgumentException($"{controller.GetType().Name} loader can't read from specified path: '{path}'.");
        }

        public static async Task<TaskResult<T>> TryReadAsync<T>(this IDataLoaderController controller, string path) where T : class
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            TaskResult<object> result = await controller.TryReadAsync(path, typeof(T));

            return result ? (T)result.Value : TaskResult<T>.Empty;
        }

        public static void Write(this IDataLoaderController controller, string path, object target)
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            if (!controller.TryWrite(path, target))
            {
                throw new ArgumentException($"{controller.GetType().Name} loader can't write at specified path: '{path}'.");
            }
        }

        public static async Task WriteAsync(this IDataLoaderController controller, string path, object target)
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            if (!await controller.TryWriteAsync(path, target))
            {
                throw new ArgumentException($"{controller.GetType().Name} loader can't write at specified path: '{path}'.");
            }
        }
    }
}
