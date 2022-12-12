using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public class DataLoaderMemory : DataLoader
    {
        public IReadOnlyDictionary<string, object> Data { get; }

        private readonly Dictionary<string, object> m_data = new Dictionary<string, object>();

        public DataLoaderMemory()
        {
            Data = new ReadOnlyDictionary<string, object>(m_data);
        }

        public void Clear()
        {
            m_data.Clear();
        }

        protected override bool OnTryRead(string path, IContext context, out object data)
        {
            return m_data.TryGetValue(path, out data);
        }

        protected override Task<TaskResult<object>> OnTryReadAsync(string path, IContext context)
        {
            return Task.FromResult<TaskResult<object>>(TryRead(path, context, out object data) ? data : TaskResult<object>.Empty);
        }

        protected override bool OnTryWrite(string path, object data, IContext context)
        {
            m_data[path] = data;
            return true;
        }

        protected override Task<bool> OnTryWriteAsync(string path, object data, IContext context)
        {
            return Task.FromResult(TryWrite(path, data, context));
        }
    }
}
