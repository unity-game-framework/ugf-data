using System;
using System.Threading.Tasks;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public interface IDataLoaderController : IController
    {
        bool TryRead(string path, Type targetType, out object target);
        Task<TaskResult<object>> TryReadAsync(string path, Type targetType);
        bool TryWrite(string path, object target);
        Task<bool> TryWriteAsync(string path, object target);
    }
}
