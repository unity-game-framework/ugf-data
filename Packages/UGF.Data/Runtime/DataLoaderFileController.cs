using System;
using System.IO;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Storage;

namespace UGF.Data.Runtime
{
    public class DataLoaderFileController : DataLoaderController
    {
        public new DataLoaderFileControllerDescription Description { get; }

        public DataLoaderFileController(DataLoaderFileControllerDescription description, IApplication application) : base(description, application)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        protected override object OnRead(string path, Type targetType)
        {
            path = GetPath(path);

            return base.OnRead(path, targetType);
        }

        protected override Task<object> OnReadAsync(string path, Type targetType)
        {
            path = GetPath(path);

            return base.OnReadAsync(path, targetType);
        }

        protected override void OnWrite(string path, object target)
        {
            path = GetPath(path);

            base.OnWrite(path, target);
        }

        protected override Task OnWriteAsync(string path, object target)
        {
            path = GetPath(path);

            return base.OnWriteAsync(path, target);
        }

        private string GetPath(string path)
        {
            string storagePath = StorageUtility.GetPath(Description.StoragePathType, Description.StoragePath);

            return Path.Combine(storagePath, path);
        }
    }
}
