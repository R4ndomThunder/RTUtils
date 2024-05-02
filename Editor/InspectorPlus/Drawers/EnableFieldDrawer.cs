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
    [CustomPropertyDrawer(typeof(EnableFieldAttribute))]
    public class EnableFieldDrawer : PropertyDrawerBase
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var enableAttribute = attribute as EnableFieldAttribute;
            var conditionalProperty = ReflectionUtility.GetValidMemberInfo(enableAttribute.ConditionName, property);

            using (new EditorGUI.DisabledGroupScope(!GetConditionValue(conditionalProperty, enableAttribute, property)))
                DrawProperty(position, property, label);
        }
    }
}