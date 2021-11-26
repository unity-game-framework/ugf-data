using UGF.Module.Controllers.Runtime;

namespace UGF.Data.Runtime
{
    public class DataLoaderControllerDescription : ControllerDescription
    {
        public string DataLoaderProviderControllerId { get; set; }
        public string DataLoaderId { get; set; }
        public string SerializerId { get; set; }
    }
}
