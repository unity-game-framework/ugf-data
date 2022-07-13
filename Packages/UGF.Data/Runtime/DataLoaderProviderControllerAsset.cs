using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.Module.Controllers.Runtime;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader Provider Controller", order = 2000)]
    public class DataLoaderProviderControllerAsset : ControllerDescribedAsset<DataLoaderProviderController, DataLoaderProviderControllerDescription>
    {
        [SerializeField] private List<AssetIdReference<DataLoaderAsset>> m_loaders = new List<AssetIdReference<DataLoaderAsset>>();

        public List<AssetIdReference<DataLoaderAsset>> Loaders { get { return m_loaders; } }

        protected override DataLoaderProviderControllerDescription OnBuildDescription()
        {
            var description = new DataLoaderProviderControllerDescription();

            for (int i = 0; i < m_loaders.Count; i++)
            {
                AssetIdReference<DataLoaderAsset> reference = m_loaders[i];

                description.Loaders.Add(reference.Guid, reference.Asset);
            }

            return description;
        }

        protected override DataLoaderProviderController OnBuild(DataLoaderProviderControllerDescription description, IApplication application)
        {
            return new DataLoaderProviderController(description, application);
        }
    }
}
