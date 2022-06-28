using System.Threading.Tasks;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public interface IDataLoader
    {
        bool TryRead(string path, IContext context, out object data);
        Task<TaskResult<object>> TryReadAsync(string path, IContext context);
        bool TryWrite(string path, object data, IContext context);
        Task<bool> TryWriteAsync(string path, object data, IContext context);
    }
}
