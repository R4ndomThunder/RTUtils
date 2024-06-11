/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEditor;
using UnityEngine;

namespace RTDK.Editor.BetterHierarchy
{
    public class SerializedPropertyElement : GUIDrawer<SerializedProperty>
    {
        private GUIContent content;

        public SerializedPropertyElement(SerializedProperty target) : base(target)
        {
            content = new GUIContent(target.displayName, target.tooltip);
        }

        protected override void OnGUI()
        {
            EditorGUI.BeginChangeCheck();

            switch (Target.propertyType)
            {
                default:
                    EditorGUILayout.PropertyField(Target);
                    break;

                case SerializedPropertyType.Boolean:
                    Target.boolValue = GUILayout.Toggle(Target.boolValue, content);
                    break;
            }

            if (EditorGUI.EndChangeCheck())
            {
                Target.serializedObject.ApplyModifiedProperties();
            }
        }

        protected override float GetHeight()
        {
            return EditorGUI.GetPropertyHeight(Target, Target.isExpanded);
        }
    }
}