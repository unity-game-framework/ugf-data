using System;

namespace UGF.Data.Runtime
{
    /// <summary>
    /// Represents an abstract data dictionary base.
    /// </summary>
    public abstract class DataDictionaryBase
    {
        /// <summary>
        /// Gets the type of the key.
        /// </summary>
        public abstract Type KeyType { get; }

        /// <summary>
        /// Gets the type of the value.
        /// </summary>
        public abstract Type ValueType { get; }

        /// <summary>
        /// Forces update serialized data to internal dictionary.
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Forces apply internal dictionary to serialized data.
        /// </summary>
        public abstract void Apply();
    }
}
