using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public abstract class DataLoaderController<TDescription> : ControllerDescribed<TDescription>, IDataLoaderController where TDescription : class, IControllerDescription
    {
        protected DataLoaderController(TDescription description, IApplication application) : base(description, application)
        {
        }

        public bool TryRead(string path, Type targetType, out object target)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (targetType == null) throw new ArgumentNullException(nameof(targetType));

            return OnTryRead(path, targetType, out target);
        }

        public Task<TaskResult<object>> TryReadAsync(string path, Type targetType)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (targetType == null) throw new ArgumentNullException(nameof(targetType));

            return OnTryReadAsync(path, targetType);
        }

        public bool TryWrite(string path, object target)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (target == null) throw new ArgumentNullException(nameof(target));

            return OnTryWrite(path, target);
        }

        public Task<bool> TryWriteAsync(string path, object target)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (target == null) throw new ArgumentNullException(nameof(target));

            return OnTryWriteAsync(path, target);
        }

        protected abstract bool OnTryRead(string path, Type targetType, out object target);
        protected abstract Task<TaskResult<object>> OnTryReadAsync(string path, Type targetType);
        protected abstract bool OnTryWrite(string path, object target);
        protected abstract Task<bool> OnTryWriteAsync(string path, object target);
    }
}
