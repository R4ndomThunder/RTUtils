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
    [CustomPropertyDrawer(typeof(ColorFieldAttribute))]
    public class ColorFieldDrawer : PropertyDrawerBase
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var colorFieldAttribute = attribute as ColorFieldAttribute;
            var prevGUIColor = GUI.color;

            if (ColorUtility.TryParseHtmlString(colorFieldAttribute.HexColor, out Color color))
            {
                GUI.color = color;
            }
            else if (!string.IsNullOrEmpty(colorFieldAttribute.HexColor))
            {
                EditorGUILayout.HelpBox($"The provided value {colorFieldAttribute.HexColor} is not a valid Hex color", MessageType.Error);
            }
            else
            {
                GUI.color = GUIColorToColor(colorFieldAttribute);
            }

            DrawProperty(position, property, label);
            GUI.color = prevGUIColor;
        }
    }
}