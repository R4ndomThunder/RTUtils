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
    [CustomPropertyDrawer(typeof(DisableFieldAttribute))]
    public class DisableFieldDrawer : PropertyDrawerBase
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var disableAttribute = attribute as DisableFieldAttribute;
            var conditionalProperty = ReflectionUtility.GetValidMemberInfo(disableAttribute.ConditionName, property);

            using (new EditorGUI.DisabledGroupScope(GetConditionValue(conditionalProperty, disableAttribute, property)))
                DrawProperty(position, property, label);
        }
    }
}