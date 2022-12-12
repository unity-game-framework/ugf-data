using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public class DataLoaderController : DataLoaderController<DataLoaderControllerDescription, IDataLoader>
    {
        public DataLoaderController(DataLoaderControllerDescription description, IApplication application) : base(description, application)
        {
        }

        protected override bool OnTryRead(IDataLoader loader, string path, Type targetType, out object target, IContext context)
        {
            return loader.TryRead(path, context, out target);
        }

        protected override Task<TaskResult<object>> OnTryReadAsync(IDataLoader loader, string path, Type targetType, IContext context)
        {
            return loader.TryReadAsync(path, context);
        }

        protected override bool OnTryWrite(IDataLoader loader, string path, object target, IContext context)
        {
            return loader.TryWrite(path, target, context);
        }

        protected override Task<bool> OnTryWriteAsync(IDataLoader loader, string path, object target, IContext context)
        {
            return loader.TryWriteAsync(path, target, context);
        }
    }
}
