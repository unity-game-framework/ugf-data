using System;
using System.Threading.Tasks;
using UGF.Module.Controllers.Runtime;

namespace UGF.Data.Runtime
{
    public interface IDataLoaderController : IController
    {
        T Read<T>(string path) where T : class;
        object Read(string path, Type targetType);
        Task<T> ReadAsync<T>(string path) where T : class;
        Task<object> ReadAsync(string path, Type targetType);
        void Write<T>(string path, T target) where T : class;
        void Write(string path, object target);
        Task WriteAsync<T>(string path, T target) where T : class;
        Task WriteAsync(string path, object target);
    }
}
