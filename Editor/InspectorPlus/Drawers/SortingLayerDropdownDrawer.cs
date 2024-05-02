/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RTDK.InspectorPlus.Editor
{
    [CustomPropertyDrawer(typeof(SortingLayerDropdownAttribute))]
    public class SortingLayerDropdownDrawer : PropertyDrawerBase
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.Integer)
            {
                property.intValue = EditorGUI.MaskField(position, label, property.intValue, GetSortingLayerNames());
            }
            else
            {
                EditorGUILayout.HelpBox("The SortingLayerDropdown attribute can only be attached to int fields", MessageType.Error);
            }
        }

        private string[] GetSortingLayerNames()
        {
            var layerList = new List<string>();

            foreach (var layer in SortingLayer.layers) layerList.Add(layer.name);

            return layerList.ToArray();
        }
    }
}