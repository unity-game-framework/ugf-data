using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader Prefs", order = 2000)]
    public class DataLoaderPrefsAsset : DataLoaderAsset
    {
        protected override IDataLoader OnBuild(IApplication arguments)
        {
            return new DataLoaderPrefs();
        }
    }
}
