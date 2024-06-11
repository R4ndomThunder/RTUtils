/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System.IO;
using UnityEditor;

namespace RTDK.Editor.BetterHierarchy
{
    // Register the Settings for the HiearchyDecorator
    public static class HierarchyDecoratorProvider
    {
        public static SettingsProvider[] tabs =
        {
            new SettingsPreferences (Constants.SETTINGS_PATH, SettingsScope.User),
        };

        private static bool SettingsExist()
        {
            return File.Exists(Constants.SETTINGS_ASSET_PATH);
        }

        [SettingsProviderGroup]
        public static SettingsProvider[] Load()
        {
            //if (SettingsExist ())
            //    return tabs;
            //else
            //    return (HierarchyDecoratorSettings.GetOrCreateSettings ()) ? tabs : null;
            return tabs;
        }
    }
}