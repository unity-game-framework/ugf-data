using System;
using System.IO;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Storage;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public class DataLoaderFileController : DataLoaderSerializeController
    {
        public new DataLoaderFileControllerDescription Description { get; }

        public DataLoaderFileController(DataLoaderFileControllerDescription description, IApplication application) : base(description, application)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        protected override bool OnTryRead(string path, Type targetType, out object target)
        {
            path = OnGetPath(path);

            return base.OnTryRead(path, targetType, out target);
        }

        protected override Task<TaskResult<object>> OnTryReadAsync(string path, Type targetType)
        {
            path = OnGetPath(path);

            return base.OnTryReadAsync(path, targetType);
        }

        protected override bool OnTryWrite(string path, object target)
        {
            path = OnGetPath(path);

            return base.OnTryWrite(path, target);
        }

        protected override Task<bool> OnTryWriteAsync(string path, object target)
        {
            path = OnGetPath(path);

            return base.OnTryWriteAsync(path, target);
        }

        protected virtual string OnGetPath(string path)
        {
            string storagePath = StorageUtility.GetPath(Description.StoragePathType, Description.StoragePath);

            path = Path.Combine(storagePath, path);

            if (!string.IsNullOrEmpty(Description.ExtensionName))
            {
                path = Path.ChangeExtension(path, Description.ExtensionName);
            }

            return path;
        }
    }
}
