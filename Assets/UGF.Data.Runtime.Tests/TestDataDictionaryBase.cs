using System;
using UnityEngine;

namespace UGF.Data.Runtime.Tests
{
    public class TestDataDictionaryBase
    {
        [Serializable]
        private class Target : DataDictionaryBase<string, TargetIem>
        {
        }

        [Serializable]
        private class TargetIem : IDataDictionaryItem<string>
        {
            [SerializeField] private string m_key;

            public string Key { get { return m_key; } set { m_key = value; } }
        }
    }
}
