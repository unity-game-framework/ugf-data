using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Controllers.Runtime;
using UGF.Serialize.Runtime;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader Controller", order = 2000)]
    public class DataLoaderControllerAsset : ControllerDescribedAsset<DataLoaderController, DataLoaderControllerDescription>
    {
        [AssetId(typeof(DataLoaderProviderControllerAsset))]
        [SerializeField] private GlobalId m_dataLoaderProviderController;
        [AssetId(typeof(DataLoaderAsset))]
        [SerializeField] private GlobalId m_dataLoader;
        [AssetId(typeof(SerializerAsset))]
        [SerializeField] private GlobalId m_serializer;

        public GlobalId DataLoaderProviderController { get { return m_dataLoaderProviderController; } set { m_dataLoaderProviderController = value; } }
        public GlobalId DataLoader { get { return m_dataLoader; } set { m_dataLoader = value; } }
        public GlobalId Serializer { get { return m_serializer; } set { m_serializer = value; } }

        protected override DataLoaderControllerDescription OnBuildDescription()
        {
            var description = new DataLoaderControllerDescription
            {
                DataLoaderProviderControllerId = m_dataLoaderProviderController,
                DataLoaderId = m_dataLoader,
                SerializerId = m_serializer
            };

            return description;
        }

        protected override DataLoaderController OnBuild(DataLoaderControllerDescription description, IApplication application)
        {
            return new DataLoaderController(description, application);
        }
    }
}
