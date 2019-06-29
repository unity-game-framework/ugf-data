using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UGF.Data.Runtime
{
    public abstract class DataDictionaryBase<TKey, TValue> : DataDictionaryBase, IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>, ISerializationCallbackReceiver where TValue : IDataDictionaryItem<TKey>
    {
        [SerializeField] private List<TValue> m_items = new List<TValue>();

        public override Type KeyType { get; } = typeof(TKey);
        public override Type ValueType { get; } = typeof(TValue);

        public int Count { get { return GetDictionary().Count; } }

        public TValue this[TKey key]
        {
            get { return GetDictionary()[key]; }
            set
            {
                value.Key = key;

                GetDictionary()[key] = value;
            }
        }

        public Dictionary<TKey, TValue>.KeyCollection Keys { get { return GetDictionary().Keys; } }
        public Dictionary<TKey, TValue>.ValueCollection Values { get { return GetDictionary().Values; } }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys { get { return ((IDictionary<TKey, TValue>)GetDictionary()).Keys; } }
        ICollection<TValue> IDictionary<TKey, TValue>.Values { get { return ((IDictionary<TKey, TValue>)GetDictionary()).Values; } }
        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly { get { return false; } }
        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys { get { return Keys; } }
        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values { get { return Values; } }

        private Dictionary<TKey, TValue> m_dictionary;

        public sealed override void Update()
        {
            if (m_dictionary == null)
            {
                m_dictionary = new Dictionary<TKey, TValue>();
            }

            OnUpdate();
        }

        public sealed override void Apply()
        {
            if (m_dictionary != null)
            {
                OnApply();
            }
        }

        public bool ContainsKey(TKey key)
        {
            return GetDictionary().ContainsKey(key);
        }

        public bool ContainsValue(TValue value)
        {
            return GetDictionary().ContainsValue(value);
        }

        public void Add(TKey key, TValue value)
        {
            GetDictionary().Add(key, value);
        }

        public bool Remove(TKey key)
        {
            return GetDictionary().Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return GetDictionary().TryGetValue(key, out value);
        }

        public void Clear()
        {
            GetDictionary().Clear();
        }

        public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
        {
            return GetDictionary().GetEnumerator();
        }

        protected virtual void OnUpdate()
        {
            for (int i = 0; i < m_items.Count; i++)
            {
                TValue item = m_items[i];

                m_dictionary.Add(item.Key, item);
            }
        }

        protected virtual void OnApply()
        {
            m_items.Clear();

            foreach (KeyValuePair<TKey, TValue> pair in m_dictionary)
            {
                m_items.Add(pair.Value);
            }
        }

        protected List<TValue> GetItems()
        {
            return m_items;
        }

        protected Dictionary<TKey, TValue> GetDictionary()
        {
            if (m_dictionary == null)
            {
                Update();
            }

            return m_dictionary;
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            Apply();
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            return ((ICollection<KeyValuePair<TKey, TValue>>)GetDictionary()).Contains(item);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)GetDictionary()).Add(item);
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            return ((ICollection<KeyValuePair<TKey, TValue>>)GetDictionary()).Remove(item);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)GetDictionary()).CopyTo(array, arrayIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)GetDictionary()).GetEnumerator();
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TKey, TValue>>)GetDictionary()).GetEnumerator();
        }
    }
}
