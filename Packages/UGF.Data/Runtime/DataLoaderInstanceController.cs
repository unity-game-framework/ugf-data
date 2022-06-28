using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public class DataLoaderInstanceController : ControllerDescribedAsync<DataLoaderInstanceControllerDescription>
    {
        public object Data { get { return m_data ?? throw new ArgumentException("Value not specified."); } }
        public bool HasData { get { return m_data != null; } }

        protected IDataLoaderController DataLoaderController { get; }

        private object m_data;

        public DataLoaderInstanceController(DataLoaderInstanceControllerDescription description, IApplication application) : base(description, application)
        {
            DataLoaderController = Application.GetController<IDataLoaderController>(Description.DataLoaderControllerId);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            if (Description.ReadOnInitialize)
            {
                TryRead(out _);
            }
        }

        protected override async Task OnInitializeAsync()
        {
            await base.OnInitializeAsync();

            if (Description.ReadOnInitializeAsync)
            {
                await TryReadAsync();
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            if (Description.WriteOnUninitialize && HasData)
            {
                TryWrite();
            }
        }

        public T Get<T>() where T : class
        {
            return (T)Data;
        }

        public void Set(object data)
        {
            m_data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public void Clear()
        {
            m_data = null;
        }

        public object Read()
        {
            Set(DataLoaderController.Read<object>(Description.Path));

            return Data;
        }

        public async Task<object> ReadAsync()
        {
            Set(await DataLoaderController.ReadAsync<object>(Description.Path));

            return Data;
        }

        public bool TryRead(out object data)
        {
            if (DataLoaderController.TryRead(Description.Path, out object value))
            {
                Set(value);

                data = Data;
                return true;
            }

            data = default;
            return false;
        }

        public async Task<TaskResult<object>> TryReadAsync()
        {
            TaskResult<object> result = await DataLoaderController.TryReadAsync<object>(Description.Path);

            if (result)
            {
                Set(result.Value);

                return Data;
            }

            return TaskResult<object>.Empty;
        }

        public void Write()
        {
            DataLoaderController.Write(Description.Path, Data);
        }

        public Task WriteAsync()
        {
            return DataLoaderController.WriteAsync(Description.Path, Data);
        }

        public bool TryWrite()
        {
            return DataLoaderController.TryWrite(Description.Path, Data);
        }

        public Task<bool> TryWriteAsync()
        {
            return DataLoaderController.TryWriteAsync(Description.Path, Data);
        }
    }
}
