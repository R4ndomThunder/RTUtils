
/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEditor;
using UnityEngine;

namespace RTDK.InspectorPlus.Editor
{
    [CustomPropertyDrawer(typeof(IndentPropertyAttribute))]
    public class IndentPropertyDrawer : PropertyDrawerBase
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var indentPropertyAttribute = attribute as IndentPropertyAttribute;

            using (new EditorGUI.IndentLevelScope(indentPropertyAttribute.IndentLevel))
                DrawProperty(position, property, label);
        }
    }
}