﻿using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UGF.Module.Controllers.Runtime;
using UnityEngine;

namespace UGF.Data.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Data Loader Instance Controller", order = 2000)]
    public class DataLoaderInstanceControllerAsset : ControllerDescribedAsset<DataLoaderInstanceController, DataLoaderInstanceControllerDescription>
    {
        [AssetGuid(typeof(DataLoaderControllerAsset))]
        [SerializeField] private string m_dataLoaderController;
        [SerializeField] private string m_path;
        [SerializeField] private bool m_readOnInitialize;
        [SerializeField] private bool m_readOnInitializeAsync;
        [SerializeField] private bool m_writeOnUninitialize;

        public string DataLoaderController { get { return m_dataLoaderController; } set { m_dataLoaderController = value; } }
        public string Path { get { return m_path; } set { m_path = value; } }
        public bool ReadOnInitialize { get { return m_readOnInitialize; } set { m_readOnInitialize = value; } }
        public bool ReadOnInitializeAsync { get { return m_readOnInitializeAsync; } set { m_readOnInitializeAsync = value; } }
        public bool WriteOnUninitialize { get { return m_writeOnUninitialize; } set { m_writeOnUninitialize = value; } }

        protected override DataLoaderInstanceControllerDescription OnBuildDescription()
        {
            var description = new DataLoaderInstanceControllerDescription
            {
                DataLoaderControllerId = m_dataLoaderController,
                Path = m_path,
                ReadOnInitialize = m_readOnInitialize,
                ReadOnInitializeAsync = m_readOnInitializeAsync,
                WriteOnUninitialize = m_writeOnUninitialize
            };

            return description;
        }

        protected override DataLoaderInstanceController OnBuild(DataLoaderInstanceControllerDescription description, IApplication application)
        {
            return new DataLoaderInstanceController(description, application);
        }
    }
}