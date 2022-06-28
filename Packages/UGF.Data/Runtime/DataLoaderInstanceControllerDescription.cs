using UGF.Module.Controllers.Runtime;

namespace UGF.Data.Runtime
{
    public class DataLoaderInstanceControllerDescription : ControllerDescription
    {
        public string DataLoaderControllerId { get; set; }
        public string Path { get; set; }
        public bool ReadOnInitialize { get; set; }
        public bool ReadOnInitializeAsync { get; set; }
        public bool WriteOnUninitialize { get; set; }
    }
}
