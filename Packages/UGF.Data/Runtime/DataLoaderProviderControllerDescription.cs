using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.Module.Controllers.Runtime;

namespace UGF.Data.Runtime
{
    public class DataLoaderProviderControllerDescription : ControllerDescription
    {
        public Dictionary<string, IBuilder<IApplication, IDataLoader>> Loaders { get; } = new Dictionary<string, IBuilder<IApplication, IDataLoader>>();
    }
}
