using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UGF.Data.Runtime.Tests
{
    public class TestDataDictionaryBase
    {
        [Serializable]
        private class Target : DataDictionaryBase<string, TargetIem>
        {
            public void SetupTestItems()
            {
                List<TargetIem> items = GetItems();

                for (int i = 0; i < 5; i++)
                {
                    items.Add(new TargetIem { Key = i.ToString() });
                }
            }

            public int GetItemsCount()
            {
                return GetItems().Count;
            }
        }

        [Serializable]
        private class TargetIem : IDataDictionaryItem<string>
        {
            [SerializeField] private string m_key;

            public string Key { get { return m_key; } set { m_key = value; } }
        }

        [Test]
        public void Indexer()
        {
            var target = new Target();
            var item = new TargetIem();

            target["0"] = item;

            Assert.True(target.Count != 0);
            Assert.AreEqual("0", item.Key);
        }

        [Test]
        public void Update()
        {
            var target = new Target();

            target.SetupTestItems();
            target.Update();

            Assert.AreEqual(5, target.Count);
        }

        [Test]
        public void UpdateImplicit()
        {
            var target = new Target();

            target.SetupTestItems();

            Assert.AreEqual(5, target.Count);
        }

        [Test]
        public void Apply()
        {
            var target = new Target();

            for (int i = 0; i < 5; i++)
            {
                target[i.ToString()] = new TargetIem();
            }

            target.Apply();

            Assert.AreEqual(5, target.GetItemsCount());
        }
    }
}
