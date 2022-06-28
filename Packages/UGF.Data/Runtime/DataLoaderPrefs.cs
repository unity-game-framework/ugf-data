using System;
using System.Threading.Tasks;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Tasks;
using UnityEngine;

namespace UGF.Data.Runtime
{
    public class DataLoaderPrefs : DataLoader
    {
        protected override bool OnTryRead(string path, IContext context, out object data)
        {
            if (PlayerPrefs.HasKey(path))
            {
                data = PlayerPrefs.GetString(path);
                return true;
            }

            data = default;
            return false;
        }

        protected override Task<TaskResult<object>> OnTryReadAsync(string path, IContext context)
        {
            return Task.FromResult(PlayerPrefs.HasKey(path) ? PlayerPrefs.GetString(path) : TaskResult<object>.Empty);
        }

        protected override bool OnTryWrite(string path, object data, IContext context)
        {
            if (data is not string text) throw new ArgumentException($"Data must be type of '{typeof(string)}'.");

            if (PlayerPrefs.HasKey(path))
            {
                PlayerPrefs.SetString(path, text);
                return true;
            }

            return false;
        }

        protected override Task<bool> OnTryWriteAsync(string path, object data, IContext context)
        {
            if (data is not string text) throw new ArgumentException($"Data must be type of '{typeof(string)}'.");

            if (PlayerPrefs.HasKey(path))
            {
                PlayerPrefs.SetString(path, text);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
