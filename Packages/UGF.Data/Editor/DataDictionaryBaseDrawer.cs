using UGF.Data.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Data.Editor
{
    [CustomPropertyDrawer(typeof(DataDictionaryBase), true)]
    internal class DataDictionaryBaseDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty propertyItems = property.FindPropertyRelative("m_items");

            EditorGUI.PropertyField(position, propertyItems, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty propertyItems = property.FindPropertyRelative("m_items");

            return EditorGUI.GetPropertyHeight(propertyItems, label);
        }
    }
}
