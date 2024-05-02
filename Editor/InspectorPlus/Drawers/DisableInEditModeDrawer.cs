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
    [CustomPropertyDrawer(typeof(DisableInEditModeAttribute))]
    public class DisableInEditModeDrawer : PropertyDrawerBase
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            using (new EditorGUI.DisabledGroupScope(!Application.isPlaying))
                DrawProperty(position, property, label);
        }
    }
}