using System.Threading.Tasks;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Data.Runtime
{
    public interface IDataLoader
    {
        T Read<T>(string path, IContext context) where T : class;
        object Read(string path, IContext context);
        Task<T> ReadAsync<T>(string path, IContext context) where T : class;
        Task<object> ReadAsync(string path, IContext context);
        void Write<T>(string path, T data, IContext context) where T : class;
        void Write(string path, object data, IContext context);
        Task WriteAsync<T>(string path, T data, IContext context) where T : class;
        Task WriteAsync(string path, object data, IContext context);
    }
}
