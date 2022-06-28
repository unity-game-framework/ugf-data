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
        protected IDataLoader DataLoader { get; }
        protected ISerializerAsync Serializer { get; }

        public DataLoaderController(DataLoaderControllerDescription description, IApplication application) : base(description, application)
        {
            DataLoaderProviderController = Application.GetController<DataLoaderProviderController>(Description.DataLoaderProviderControllerId);
            SerializeModule = Application.GetModule<ISerializeModule>();
            DataLoader = DataLoaderProviderController.Provider.Get(Description.DataLoaderId);
            Serializer = SerializeModule.Provider.Get<ISerializerAsync>(Description.SerializerId);
        }

        protected override bool OnTryRead(string path, Type targetType, out object target)
        {
            if (DataLoader.TryRead(path, DataLoaderProviderController.Context, out object data))
            {
                target = Serializer.Deserialize(targetType, data, SerializeModule.Context);
                return true;
            }

            target = default;
            return false;
        }

        protected override async Task<TaskResult<object>> OnTryReadAsync(string path, Type targetType)
        {
            TaskResult<object> result = await DataLoader.TryReadAsync(path, DataLoaderProviderController.Context);

            if (result)
            {
                return await Serializer.DeserializeAsync(targetType, result.Value, SerializeModule.Context);
            }

            return TaskResult<object>.Empty;
        }

        protected override bool OnTryWrite(string path, object target)
        {
            object data = Serializer.Serialize(target, SerializeModule.Context);

            return DataLoader.TryWrite(path, data, DataLoaderProviderController.Context);
        }

        protected override async Task<bool> OnTryWriteAsync(string path, object target)
        {
            object data = await Serializer.SerializeAsync(target, SerializeModule.Context);

            return await DataLoader.TryWriteAsync(path, data, DataLoaderProviderController.Context);
        }
    }
}
