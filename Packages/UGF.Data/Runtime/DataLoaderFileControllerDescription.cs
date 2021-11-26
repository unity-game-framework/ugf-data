using UGF.RuntimeTools.Runtime.Storage;

namespace UGF.Data.Runtime
{
    public class DataLoaderFileControllerDescription : DataLoaderControllerDescription
    {
        public StoragePathType StoragePathType { get; set; }
        public string StoragePath { get; set; }
    }
}
