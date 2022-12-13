using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public abstract class DataLoaderController<TDescription, TLoader> : DataLoaderController<TDescription>
        where TDescription : DataLoaderControllerDescription
        where TLoader : class, IDataLoader
    {
        protected DataLoaderProviderController DataLoaderProviderController { get; }

        protected DataLoaderController(TDescription description, IApplication application) : base(description, application)
        {
            DataLoaderProviderController = Application.GetController<DataLoaderProviderController>(Description.DataLoaderProviderControllerId);
        }

        protected override bool OnTryRead(string path, Type targetType, out object target)
        {
            var loader = DataLoaderProviderController.Provider.Get<TLoader>(Description.DataLoaderId);

            return OnTryRead(loader, path, targetType, out target, DataLoaderProviderController.Context);
        }

        protected override Task<TaskResult<object>> OnTryReadAsync(string path, Type targetType)
        {
            var loader = DataLoaderProviderController.Provider.Get<TLoader>(Description.DataLoaderId);

            return OnTryReadAsync(loader, path, targetType, DataLoaderProviderController.Context);
        }

        protected override bool OnTryWrite(string path, object target)
        {
            var loader = DataLoaderProviderController.Provider.Get<TLoader>(Description.DataLoaderId);

            return OnTryWrite(loader, path, target, DataLoaderProviderController.Context);
        }

        protected override Task<bool> OnTryWriteAsync(string path, object target)
        {
            var loader = DataLoaderProviderController.Provider.Get<TLoader>(Description.DataLoaderId);

            return OnTryWriteAsync(loader, path, target, DataLoaderProviderController.Context);
        }

        protected abstract bool OnTryRead(TLoader loader, string path, Type targetType, out object target, IContext context);
        protected abstract Task<TaskResult<object>> OnTryReadAsync(TLoader loader, string path, Type targetType, IContext context);
        protected abstract bool OnTryWrite(TLoader loader, string path, object target, IContext context);
        protected abstract Task<bool> OnTryWriteAsync(TLoader loader, string path, object target, IContext context);
    }
}
