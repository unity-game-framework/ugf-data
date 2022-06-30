using System;
using System.Threading.Tasks;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public static class DataLoaderInstanceControllerExtensions
    {
        public static T GetOrCreate<T>(this DataLoaderInstanceController controller) where T : class, new()
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            if (!controller.HasData)
            {
                controller.Set(new T());
            }

            return controller.Get<T>();
        }

        public static T Read<T>(this DataLoaderInstanceController controller) where T : class
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            return (T)controller.Read();
        }

        public static async Task<T> ReadAsync<T>(this DataLoaderInstanceController controller) where T : class
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            return (T)await controller.ReadAsync();
        }

        public static bool TryRead<T>(this DataLoaderInstanceController controller, out T data) where T : class
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            if (controller.TryRead(out object value))
            {
                data = (T)value;
                return true;
            }

            data = default;
            return false;
        }

        public static async Task<TaskResult<T>> TryReadAsync<T>(this DataLoaderInstanceController controller) where T : class
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            TaskResult<object> result = await controller.TryReadAsync();

            return result ? (T)result.Value : TaskResult<T>.Empty;
        }
    }
}
