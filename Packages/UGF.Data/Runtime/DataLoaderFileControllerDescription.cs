using UGF.RuntimeTools.Runtime.Storage;

namespace UGF.Data.Runtime
{
    public class DataLoaderFileControllerDescription : DataLoaderSerializeControllerDescription
    {
        public StoragePathType StoragePathType { get; set; }
        public string StoragePath { get; set; }
    }
}
