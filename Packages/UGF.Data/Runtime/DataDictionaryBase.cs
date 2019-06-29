using System;

namespace UGF.Data.Runtime
{
    public abstract class DataDictionaryBase
    {
        public abstract Type KeyType { get; }
        public abstract Type ValueType { get; }

        public abstract void Update();
        public abstract void Apply();
    }
}
