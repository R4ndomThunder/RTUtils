/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace RTDK.Editor.BetterHierarchy
{
    public class SettingsPreferences : SettingsProvider
    {
        //--- Settings ---
        private static Settings settings;

        private static SerializedObject serializedSettings;
        private static UnityEditor.Editor settingsEditor;

        //Constructor
        public SettingsPreferences(string path, SettingsScope scope = SettingsScope.User) : base(path, scope) { }

        //Activate and Deactivate for saving/loading
        public override void OnDeactivate()
        {
            base.OnDeactivate();
        }

        // On Load of Window
        public override void OnActivate(System.String searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);

            if (settings == null)
            {
                settings = HierarchyDecorator.GetOrCreateSettings();
                serializedSettings = HierarchyDecorator.GetSerializedSettings();
            }
        }

        // GUI
        public override void OnTitleBarGUI()
        {
            base.OnTitleBarGUI();
        }

        public override void OnGUI(string searchContext)
        {
            if (settings == null)
            {
                EditorGUILayout.LabelField("Cannot find settings in project", EditorStyles.boldLabel);
                return;
            }

            DrawSettings();
        }

        public override void OnFooterBarGUI()
        {
            base.OnFooterBarGUI();
        }

        private void DrawSettings()
        {
            if (settingsEditor == null)
            {
                UnityEditor.Editor.CreateCachedEditor(settings, null, ref settingsEditor);
                return;
            }

            settingsEditor.OnInspectorGUI();
        }
    }
}