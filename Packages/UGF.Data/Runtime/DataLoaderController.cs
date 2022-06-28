using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.Module.Serialize.Runtime;
using UGF.Serialize.Runtime;

namespace UGF.Data.Runtime
{
    public class DataLoaderController : ControllerDescribed<DataLoaderControllerDescription>, IDataLoaderController
    {
        protected IControllerModule ControllerModule { get; }
        protected ISerializeModule SerializeModule { get; }

        public DataLoaderController(DataLoaderControllerDescription description, IApplication application) : base(description, application)
        {
            ControllerModule = Application.GetModule<IControllerModule>();
            SerializeModule = Application.GetModule<ISerializeModule>();
        }

        public T Read<T>(string path) where T : class
        {
            return (T)Read(path, typeof(T));
        }

        public object Read(string path, Type targetType)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (targetType == null) throw new ArgumentNullException(nameof(targetType));

            return OnRead(path, targetType);
        }

        public async Task<T> ReadAsync<T>(string path) where T : class
        {
            return (T)await ReadAsync(path, typeof(T));
        }

        public Task<object> ReadAsync(string path, Type targetType)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (targetType == null) throw new ArgumentNullException(nameof(targetType));

            return OnReadAsync(path, targetType);
        }

        public void Write<T>(string path, T target) where T : class
        {
            Write(path, (object)target);
        }

        public void Write(string path, object target)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (target == null) throw new ArgumentNullException(nameof(target));

            OnWrite(path, target);
        }

        public Task WriteAsync<T>(string path, T target) where T : class
        {
            return WriteAsync(path, (object)target);
        }

        public Task WriteAsync(string path, object target)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (target == null) throw new ArgumentNullException(nameof(target));

            return OnWriteAsync(path, target);
        }

        protected virtual object OnRead(string path, Type targetType)
        {
            var providerController = ControllerModule.Provider.Get<DataLoaderProviderController>(Description.DataLoaderProviderControllerId);
            var loader = providerController.Provider.Get<IDataLoader>(Description.DataLoaderId);
            var serializer = SerializeModule.Provider.Get<ISerializer>(Description.SerializerId);

            object data = DataLoaderExtensions.Read(path, providerController.Context);
            object target = serializer.Deserialize(targetType, data, SerializeModule.Context);

            return target;
        }

        protected virtual async Task<object> OnReadAsync(string path, Type targetType)
        {
            var providerController = ControllerModule.Provider.Get<DataLoaderProviderController>(Description.DataLoaderProviderControllerId);
            var loader = providerController.Provider.Get<IDataLoader>(Description.DataLoaderId);
            var serializer = SerializeModule.Provider.Get<ISerializerAsync>(Description.SerializerId);

            object data = await loader.ReadAsync(path, providerController.Context);
            object target = await serializer.DeserializeAsync(targetType, data, SerializeModule.Context);

            return target;
        }

        protected virtual void OnWrite(string path, object target)
        {
            var providerController = ControllerModule.Provider.Get<DataLoaderProviderController>(Description.DataLoaderProviderControllerId);
            var loader = providerController.Provider.Get<IDataLoader>(Description.DataLoaderId);
            var serializer = SerializeModule.Provider.Get<ISerializer>(Description.SerializerId);

            object data = serializer.Serialize(target, SerializeModule.Context);

            loader.Write(path, data, providerController.Context);
        }

        protected virtual async Task OnWriteAsync(string path, object target)
        {
            var providerController = ControllerModule.Provider.Get<DataLoaderProviderController>(Description.DataLoaderProviderControllerId);
            var loader = providerController.Provider.Get<IDataLoader>(Description.DataLoaderId);
            var serializer = SerializeModule.Provider.Get<ISerializerAsync>(Description.SerializerId);

            object data = await serializer.SerializeAsync(target, SerializeModule.Context);

            await loader.WriteAsync(path, data, providerController.Context);
        }
    }
}
