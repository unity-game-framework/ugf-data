using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader Memory Controller", order = 2000)]
    public class DataLoaderMemoryControllerAsset : ControllerAsset
    {
        protected override IController OnBuild(IApplication arguments)
        {
            return new DataLoaderMemoryController(arguments);
        }
    }
}
