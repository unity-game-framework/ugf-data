using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Controllers.Runtime;

namespace UGF.Data.Runtime
{
    public class DataLoaderControllerDescription : ControllerDescription
    {
        public GlobalId DataLoaderProviderControllerId { get; set; }
        public GlobalId DataLoaderId { get; set; }
    }
}
