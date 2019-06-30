using System;
using UnityEngine;

namespace UGF.Data.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestDictionaryScriptableObject")]
    public class TestDictionaryScriptableObject : ScriptableObject
    {
        [SerializeField] private DictionaryCollection m_collection = new DictionaryCollection();
        [SerializeField] private DictionaryCollection2 m_collection2 = new DictionaryCollection2();
        [SerializeField] private DictionaryCollection3 m_collection3 = new DictionaryCollection3();
        [SerializeField] private bool m_boolValue;
        [SerializeField] private TypeCode m_enumValue;
        [SerializeField] private float m_floatValue;
        [SerializeField] private Vector4 m_vector4Value;

        public DictionaryCollection Collection { get { return m_collection; } }
        public DictionaryCollection2 Collection2 { get { return m_collection2; } }
        public DictionaryCollection3 Collection3 { get { return m_collection3; } }
        public bool BoolValue { get { return m_boolValue; } set { m_boolValue = value; } }
        public TypeCode EnumValue { get { return m_enumValue; } set { m_enumValue = value; } }
        public float FloatValue { get { return m_floatValue; } set { m_floatValue = value; } }
        public Vector4 Vector4Value { get { return m_vector4Value; } set { m_vector4Value = value; } }

        [Serializable]
        public class DictionaryCollection : DataDictionaryBase<string, DictionaryItem1>
        {
        }

        [Serializable]
        public class DictionaryCollection2 : DataDictionaryBase<int, DictionaryItem2>
        {
        }

        [Serializable]
        public class DictionaryCollection3 : DataDictionaryBase<TypeCode, DictionaryItem3>
        {
        }

        [Serializable]
        public class DictionaryItem1 : DictionaryItem<string>
        {
        }

        [Serializable]
        public class DictionaryItem2 : DictionaryItem<int>
        {
        }

        [Serializable]
        public class DictionaryItem3 : DictionaryItem<TypeCode>
        {
        }

        public abstract class DictionaryItem<TKey> : DataDictionaryItemBase<TKey>
        {
            [SerializeField] private bool m_boolValue;
            [SerializeField] private TypeCode m_enumValue;
            [SerializeField] private float m_floatValue;
            [SerializeField] private Vector4 m_vector4Value;

            public bool BoolValue { get { return m_boolValue; } set { m_boolValue = value; } }
            public TypeCode EnumValue { get { return m_enumValue; } set { m_enumValue = value; } }
            public float FloatValue { get { return m_floatValue; } set { m_floatValue = value; } }
            public Vector4 Vector4Value { get { return m_vector4Value; } set { m_vector4Value = value; } }
        }
    }
}
