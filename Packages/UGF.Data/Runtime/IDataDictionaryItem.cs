namespace UGF.Data.Runtime
{
    /// <summary>
    /// Represents a data dictionary item with the specified key type.
    /// </summary>
    public interface IDataDictionaryItem<TKey>
    {
        /// <summary>
        /// Gets or sets the item key.
        /// </summary>
        TKey Key { get; set; }
    }
}
