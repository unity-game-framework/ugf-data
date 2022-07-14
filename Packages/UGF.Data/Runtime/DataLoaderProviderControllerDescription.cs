using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Controllers.Runtime;

namespace UGF.Data.Runtime
{
    public class DataLoaderProviderControllerDescription : ControllerDescription
    {
        public Dictionary<GlobalId, IBuilder<IApplication, IDataLoader>> Loaders { get; } = new Dictionary<GlobalId, IBuilder<IApplication, IDataLoader>>();
    }
}
