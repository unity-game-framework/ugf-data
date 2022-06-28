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
                Read();
            }
        }

        protected override async Task OnInitializeAsync()
        {
            await base.OnInitializeAsync();

            if (Description.ReadOnInitializeAsync)
            {
                await ReadAsync();
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            if (Description.WriteOnUninitialize && HasData)
            {
                Write();
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
            return DataLoaderController.Read<object>(Description.Path);
        }

        public Task<object> ReadAsync()
        {
            return DataLoaderController.ReadAsync<object>(Description.Path);
        }

        public bool TryRead(out object data)
        {
            return DataLoaderController.TryRead(Description.Path, out data);
        }

        public Task<TaskResult<object>> TryReadAsync()
        {
            return DataLoaderController.TryReadAsync<object>(Description.Path);
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
