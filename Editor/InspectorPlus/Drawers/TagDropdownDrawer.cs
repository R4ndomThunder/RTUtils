/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace RTDK.InspectorPlus.Editor
{
    [CustomPropertyDrawer(typeof(TagDropdownAttribute))]
    public class TagDropdownDrawer : PropertyDrawerBase
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.String)
            {
                property.stringValue = EditorGUI.TagField(position, label, DoesStringValueContainTag(property.stringValue) ? property.stringValue : "Untagged");
            }
            else
            {
                EditorGUILayout.HelpBox("The TagDropdown attribute can only be attached to string fields", MessageType.Error);
            }
        }

        private bool DoesStringValueContainTag(string stringValue)
        {
            foreach (var tag in InternalEditorUtility.tags)
            {
                if (stringValue == tag) return true;
            }

            return false;
        }
    }
}