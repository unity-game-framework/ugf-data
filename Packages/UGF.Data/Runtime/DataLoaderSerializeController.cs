using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Serialize.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Tasks;
using UGF.Serialize.Runtime;

namespace UGF.Data.Runtime
{
    public class DataLoaderSerializeController : DataLoaderController<DataLoaderSerializeControllerDescription, IDataLoader>
    {
        protected ISerializeModule SerializeModule { get; }

        public DataLoaderSerializeController(DataLoaderSerializeControllerDescription description, IApplication application) : base(description, application)
        {
            SerializeModule = Application.GetModule<ISerializeModule>();
        }

        protected override bool OnTryRead(IDataLoader loader, string path, Type targetType, out object target, IContext context)
        {
            var serializer = SerializeModule.Provider.Get<ISerializerAsync>(Description.SerializerId);

            if (loader.TryRead(path, DataLoaderProviderController.Context, out object data))
            {
                target = serializer.Deserialize(targetType, data, context);
                return true;
            }

            target = default;
            return false;
        }

        protected override async Task<TaskResult<object>> OnTryReadAsync(IDataLoader loader, string path, Type targetType, IContext context)
        {
            var serializer = SerializeModule.Provider.Get<ISerializerAsync>(Description.SerializerId);

            TaskResult<object> result = await loader.TryReadAsync(path, context);

            if (result)
            {
                return await serializer.DeserializeAsync(targetType, result.Value, SerializeModule.Context);
            }

            return TaskResult<object>.Empty;
        }

        protected override bool OnTryWrite(IDataLoader loader, string path, object target, IContext context)
        {
            var serializer = SerializeModule.Provider.Get<ISerializerAsync>(Description.SerializerId);

            object data = serializer.Serialize(target, SerializeModule.Context);

            return loader.TryWrite(path, data, context);
        }

        protected override async Task<bool> OnTryWriteAsync(IDataLoader loader, string path, object target, IContext context)
        {
            var serializer = SerializeModule.Provider.Get<ISerializerAsync>(Description.SerializerId);

            object data = await serializer.SerializeAsync(target, SerializeModule.Context);

            return await loader.TryWriteAsync(path, data, context);
        }
    }
}
