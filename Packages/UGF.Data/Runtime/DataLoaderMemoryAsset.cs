using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader Memory", order = 2000)]
    public class DataLoaderMemoryAsset : DataLoaderAsset
    {
        protected override IDataLoader OnBuild(IApplication arguments)
        {
            return new DataLoaderMemory();
        }
    }
}
