using System.Text;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Encodings;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader File Text", order = 2000)]
    public class DataLoaderFileTextAsset : DataLoaderAsset
    {
        [SerializeField] private EncodingType m_encoding = EncodingType.Default;

        public EncodingType Encoding { get { return m_encoding; } set { m_encoding = value; } }

        protected override IDataLoader OnBuild(IApplication arguments)
        {
            Encoding encoding = EncodingUtility.GetEncoding(m_encoding);

            return new DataLoaderFileText(encoding);
        }
    }
}
