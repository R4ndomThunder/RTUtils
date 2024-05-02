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
    [CustomPropertyDrawer(typeof(ButtonFieldAttribute))]
    public class ButtonFieldDrawer : PropertyDrawerBase
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var buttonFieldAttribute = attribute as ButtonFieldAttribute;
            var target = property.serializedObject.targetObject;

            var function = ReflectionUtility.FindFunction(buttonFieldAttribute.FunctionName, target);
            var functionParameters = function.GetParameters();

            if (functionParameters.Length == 0)
            {
                if (GUILayout.Button(string.IsNullOrWhiteSpace(buttonFieldAttribute.Label) ? function.Name : buttonFieldAttribute.Label, GUILayout.Height(buttonFieldAttribute.Height)))
                    function.Invoke(target, null);
            }
            else
            {
                EditorGUILayout.HelpBox("Function cannot have parameters", MessageType.Error);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => -EditorGUIUtility.standardVerticalSpacing;
    }
}