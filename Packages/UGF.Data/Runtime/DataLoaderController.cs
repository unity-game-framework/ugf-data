using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.Module.Serialize.Runtime;
using UGF.RuntimeTools.Runtime.Tasks;
using UGF.Serialize.Runtime;

namespace UGF.Data.Runtime
{
    public class DataLoaderController : DataLoaderController<DataLoaderControllerDescription>
    {
        protected DataLoaderProviderController DataLoaderProviderController { get; }
        protected ISerializeModule SerializeModule { get; }

        public DataLoaderController(DataLoaderControllerDescription description, IApplication application) : base(description, application)
        {
            DataLoaderProviderController = Application.GetController<DataLoaderProviderController>(Description.DataLoaderProviderControllerId);
            SerializeModule = Application.GetModule<ISerializeModule>();
        }

        protected override bool OnTryRead(string path, Type targetType, out object target)
        {
            IDataLoader loader = DataLoaderProviderController.Provider.Get(Description.DataLoaderId);
            var serializer = SerializeModule.Provider.Get<ISerializerAsync>(Description.SerializerId);

            if (loader.TryRead(path, DataLoaderProviderController.Context, out object data))
            {
                target = serializer.Deserialize(targetType, data, SerializeModule.Context);
                return true;
            }

            target = default;
            return false;
        }

        protected override async Task<TaskResult<object>> OnTryReadAsync(string path, Type targetType)
        {
            IDataLoader loader = DataLoaderProviderController.Provider.Get(Description.DataLoaderId);
            var serializer = SerializeModule.Provider.Get<ISerializerAsync>(Description.SerializerId);

            TaskResult<object> result = await loader.TryReadAsync(path, DataLoaderProviderController.Context);

            if (result)
            {
                return await serializer.DeserializeAsync(targetType, result.Value, SerializeModule.Context);
            }

            return TaskResult<object>.Empty;
        }

        protected override bool OnTryWrite(string path, object target)
        {
            IDataLoader loader = DataLoaderProviderController.Provider.Get(Description.DataLoaderId);
            var serializer = SerializeModule.Provider.Get<ISerializerAsync>(Description.SerializerId);

            object data = serializer.Serialize(target, SerializeModule.Context);

            return loader.TryWrite(path, data, DataLoaderProviderController.Context);
        }

        protected override async Task<bool> OnTryWriteAsync(string path, object target)
        {
            IDataLoader loader = DataLoaderProviderController.Provider.Get(Description.DataLoaderId);
            var serializer = SerializeModule.Provider.Get<ISerializerAsync>(Description.SerializerId);

            object data = await serializer.SerializeAsync(target, SerializeModule.Context);

            return await loader.TryWriteAsync(path, data, DataLoaderProviderController.Context);
        }
    }
}
