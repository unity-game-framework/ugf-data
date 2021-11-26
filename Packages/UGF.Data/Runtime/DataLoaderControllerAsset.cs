using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UGF.Module.Controllers.Runtime;
using UGF.Serialize.Runtime;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader Controller", order = 2000)]
    public class DataLoaderControllerAsset : ControllerDescribedAsset<DataLoaderController, DataLoaderControllerDescription>
    {
        [AssetGuid(typeof(DataLoaderProviderControllerAsset))]
        [SerializeField] private string m_dataLoaderProviderController;
        [AssetGuid(typeof(DataLoaderAsset))]
        [SerializeField] private string m_dataLoader;
        [AssetGuid(typeof(SerializerAsset))]
        [SerializeField] private string m_serializer;

        public string DataLoaderProviderController { get { return m_dataLoaderProviderController; } set { m_dataLoaderProviderController = value; } }
        public string DataLoader { get { return m_dataLoader; } set { m_dataLoader = value; } }
        public string Serializer { get { return m_serializer; } set { m_serializer = value; } }

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
