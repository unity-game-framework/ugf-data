using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Storage;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader File Controller", order = 2000)]
    public class DataLoaderFileControllerAsset : DataLoaderControllerAsset
    {
        [SerializeField] private StoragePathType m_storagePathType;
        [SerializeField] private string m_storagePath;

        public StoragePathType StoragePathType { get { return m_storagePathType; } set { m_storagePathType = value; } }
        public string StoragePath { get { return m_storagePath; } set { m_storagePath = value; } }

        protected override DataLoaderControllerDescription OnBuildDescription()
        {
            var description = new DataLoaderFileControllerDescription
            {
                DataLoaderProviderControllerId = DataLoaderProviderController,
                DataLoaderId = DataLoader,
                SerializerId = Serializer,
                StoragePathType = m_storagePathType,
                StoragePath = m_storagePath
            };

            return description;
        }

        protected override DataLoaderController OnBuild(DataLoaderControllerDescription description, IApplication application)
        {
            return new DataLoaderFileController((DataLoaderFileControllerDescription)description, application);
        }
    }
}
