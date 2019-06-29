using UnityEngine;

namespace UGF.Data.Runtime
{
    public abstract class DataDictionaryItemBase<TKey> : IDataDictionaryItem<TKey>
    {
        [SerializeField] private TKey m_key;

        public TKey Key { get { return m_key; } set { m_key = value; } }
    }
}
