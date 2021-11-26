using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader File Bytes", order = 2000)]
    public class DataLoaderFileBytesAsset : DataLoaderAsset
    {
        protected override IDataLoader OnBuild(IApplication arguments)
        {
            return new DataLoaderFileBytes();
        }
    }
}
