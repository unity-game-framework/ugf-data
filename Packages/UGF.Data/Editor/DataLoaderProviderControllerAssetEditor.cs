using UGF.Data.Runtime;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.AssetReferences;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;

namespace UGF.Data.Editor
{
    [CustomEditor(typeof(DataLoaderProviderControllerAsset), true)]
    internal class DataLoaderProviderControllerAssetEditor : UnityEditor.Editor
    {
        private AssetReferenceListDrawer m_listLoaders;
        private ReorderableListSelectionDrawerByPath m_listLoadersSelection;

        private void OnEnable()
        {
            m_listLoaders = new AssetReferenceListDrawer(serializedObject.FindProperty("m_loaders"));

            m_listLoadersSelection = new ReorderableListSelectionDrawerByPath(m_listLoaders, "m_asset")
            {
                Drawer =
                {
                    DisplayTitlebar = true
                }
            };

            m_listLoaders.Enable();
            m_listLoadersSelection.Enable();
        }

        private void OnDisable()
        {
            m_listLoaders.Disable();
            m_listLoadersSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listLoaders.DrawGUILayout();
                m_listLoadersSelection.DrawGUILayout();
            }
        }
    }
}
