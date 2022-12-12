using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public class DataLoaderMemoryController : DataLoaderController<ControllerDescription>
    {
        private readonly Dictionary<string, object> m_data = new Dictionary<string, object>();

        public DataLoaderMemoryController(IApplication application) : base(new ControllerDescription(), application)
        {
        }

        protected override bool OnTryRead(string path, Type targetType, out object target)
        {
            return m_data.TryGetValue(path, out target);
        }

        protected override Task<TaskResult<object>> OnTryReadAsync(string path, Type targetType)
        {
            return Task.FromResult<TaskResult<object>>(TryRead(path, targetType, out object target) ? target : TaskResult<object>.Empty);
        }

        protected override bool OnTryWrite(string path, object target)
        {
            m_data[path] = target;
            return true;
        }

        protected override Task<bool> OnTryWriteAsync(string path, object target)
        {
            return Task.FromResult(TryWrite(path, target));
        }
    }
}
