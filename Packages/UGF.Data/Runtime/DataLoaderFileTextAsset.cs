using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader File Text", order = 2000)]
    public class DataLoaderFileTextAsset : DataLoaderAsset
    {
        protected override IDataLoader OnBuild(IApplication arguments)
        {
            return new DataLoaderFileText();
        }
    }
}
