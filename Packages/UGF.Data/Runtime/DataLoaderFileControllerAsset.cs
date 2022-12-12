using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Storage;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader File Controller", order = 2000)]
    public class DataLoaderFileControllerAsset : DataLoaderSerializeControllerAsset
    {
        [SerializeField] private StoragePathType m_storagePathType;
        [SerializeField] private string m_storagePath;
        [SerializeField] private string m_extensionName;

        public StoragePathType StoragePathType { get { return m_storagePathType; } set { m_storagePathType = value; } }
        public string StoragePath { get { return m_storagePath; } set { m_storagePath = value; } }
        public string ExtensionName { get { return m_extensionName; } set { m_extensionName = value; } }

        protected override DataLoaderSerializeControllerDescription OnBuildDescription()
        {
            var description = new DataLoaderFileControllerDescription
            {
                DataLoaderProviderControllerId = DataLoaderProviderController,
                DataLoaderId = DataLoader,
                SerializerId = Serializer,
                StoragePathType = m_storagePathType,
                StoragePath = m_storagePath,
                ExtensionName = m_extensionName
            };

            return description;
        }

        protected override DataLoaderSerializeController OnBuild(DataLoaderSerializeControllerDescription description, IApplication application)
        {
            return new DataLoaderFileController((DataLoaderFileControllerDescription)description, application);
        }
    }
}
