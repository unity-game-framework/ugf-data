using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UGF.Data.Runtime
{
    /// <summary>
    /// Represents an abstract serializable dictionary with the specified type of the key and value.
    /// </summary>
    public abstract class DataDictionaryBase<TKey, TValue> : DataDictionaryBase, IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>, ISerializationCallbackReceiver where TValue : IDataDictionaryItem<TKey>
    {
        [SerializeField] private List<TValue> m_items = new List<TValue>();

        public override Type KeyType { get; } = typeof(TKey);
        public override Type ValueType { get; } = typeof(TValue);

        /// <summary>
        /// Gets the number of key/value pairs contained in the <see cref="T:System.Collections.Generic.Dictionary`2" />.
        /// </summary>
        public int Count { get { return GetDictionary().Count; } }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get or set.</param>
        public TValue this[TKey key]
        {
            get { return GetDictionary()[key]; }
            set
            {
                value.Key = key;

                GetDictionary()[key] = value;
            }
        }

        /// <summary>
        /// Gets a collection containing the keys in the <see cref="T:System.Collections.Generic.Dictionary`2" />.
        /// </summary>
        public Dictionary<TKey, TValue>.KeyCollection Keys { get { return GetDictionary().Keys; } }

        /// <summary>
        /// Gets a collection containing the values in the <see cref="T:System.Collections.Generic.Dictionary`2" />.
        /// </summary>
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

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.Dictionary`2" /> contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="T:System.Collections.Generic.Dictionary`2" />.</param>
        public bool ContainsKey(TKey key)
        {
            return GetDictionary().ContainsKey(key);
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.Dictionary`2" /> contains a specific value.
        /// </summary>
        /// <param name="value">The value to locate in the <see cref="T:System.Collections.Generic.Dictionary`2" />. The value can be <see langword="null" /> for reference types.</param>
        public bool ContainsValue(TValue value)
        {
            return GetDictionary().ContainsValue(value);
        }

        /// <summary>
        /// Adds the specified key and value to the dictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be <see langword="null" /> for reference types.</param>
        public void Add(TKey key, TValue value)
        {
            GetDictionary().Add(key, value);
        }

        /// <summary>
        /// Removes the value with the specified key from the <see cref="T:System.Collections.Generic.Dictionary`2" />.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        public bool Remove(TKey key)
        {
            return GetDictionary().Remove(key);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value" /> parameter. This parameter is passed uninitialized.</param>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return GetDictionary().TryGetValue(key, out value);
        }

        /// <summary>
        /// Removes all keys and values from the <see cref="T:System.Collections.Generic.Dictionary`2" />.
        /// </summary>
        public void Clear()
        {
            GetDictionary().Clear();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="T:System.Collections.Generic.Dictionary`2" />.
        /// </summary>
        public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
        {
            return GetDictionary().GetEnumerator();
        }

        /// <summary>
        /// Invoked when update is called.
        /// </summary>
        protected virtual void OnUpdate()
        {
            for (int i = 0; i < m_items.Count; i++)
            {
                TValue item = m_items[i];

                m_dictionary.Add(item.Key, item);
            }
        }

        /// <summary>
        /// Invoked when apply is called or before serialize.
        /// </summary>
        protected virtual void OnApply()
        {
            m_items.Clear();

            foreach (KeyValuePair<TKey, TValue> pair in m_dictionary)
            {
                m_items.Add(pair.Value);
            }
        }

        /// <summary>
        /// Gets the internal serialized items collection.
        /// </summary>
        protected List<TValue> GetItems()
        {
            return m_items;
        }

        /// <summary>
        /// Gets the internal dictionary.
        /// <para>
        /// If the internal dictionary not initialized, will create and update the new one.
        /// </para>
        /// </summary>
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
