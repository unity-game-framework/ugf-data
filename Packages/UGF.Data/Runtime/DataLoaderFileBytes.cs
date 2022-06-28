using System;
using System.IO;
using System.Threading.Tasks;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Tasks;

namespace UGF.Data.Runtime
{
    public class DataLoaderFileBytes : DataLoader
    {
        protected override bool OnTryRead(string path, IContext context, out object data)
        {
            if (File.Exists(path))
            {
                try
                {
                    data = File.ReadAllBytes(path);
                    return true;
                }
                catch (Exception exception)
                {
                    Log.Warning(exception);
                }
            }

            data = default;
            return false;
        }

        protected override async Task<TaskResult<object>> OnTryReadAsync(string path, IContext context)
        {
            if (File.Exists(path))
            {
                try
                {
                    return await File.ReadAllBytesAsync(path);
                }
                catch (Exception exception)
                {
                    Log.Warning(exception);
                }
            }

            return TaskResult<object>.Empty;
        }

        protected override bool OnTryWrite(string path, object data, IContext context)
        {
            if (data is not byte[] bytes) throw new ArgumentException($"Data must be type of '{typeof(byte[])}'.");

            CreateDirectoryForFile(path);

            try
            {
                File.WriteAllBytes(path, bytes);
                return true;
            }
            catch (Exception exception)
            {
                Log.Warning(exception);
                return false;
            }
        }

        protected override async Task<bool> OnTryWriteAsync(string path, object data, IContext context)
        {
            if (data is not byte[] bytes) throw new ArgumentException($"Data must be type of '{typeof(byte[])}'.");

            CreateDirectoryForFile(path);

            try
            {
                await File.WriteAllBytesAsync(path, bytes);
                return true;
            }
            catch (Exception exception)
            {
                Log.Warning(exception);
                return false;
            }
        }

        private void CreateDirectoryForFile(string path)
        {
            string directoryPath = Path.GetDirectoryName(path);

            if (!string.IsNullOrEmpty(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
