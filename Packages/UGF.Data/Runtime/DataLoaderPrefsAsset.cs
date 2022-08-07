using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader Prefs", order = 2000)]
    public class DataLoaderPrefsAsset : DataLoaderAsset
    {
        [SerializeField] private bool m_saveOnWrite;

        public bool SaveOnWrite { get { return m_saveOnWrite; } set { m_saveOnWrite = value; } }

        protected override IDataLoader OnBuild(IApplication arguments)
        {
            return new DataLoaderPrefs(m_saveOnWrite);
        }
    }
}
