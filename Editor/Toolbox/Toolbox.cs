/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RTDK.Editor.Toolbox
{
    /// <summary>
    /// 
    /// </summary>
    public class Toolbox : MonoBehaviour
    {
        [MenuItem("RTDK/Tools/Generate Project Folders")]
        public static void GenerateProjectFolders()
        {

        }

        [MenuItem("RTDK/Capture Screenshot")]
        public static void CaptureScreenshot()
        {
            ScreenCapture.CaptureScreenshot($"{Application.dataPath + "/" + SceneManager.GetActiveScene().name}-{DateTime.Now:dd-MM-yyyy-hh-mm-ss-fff}.png");
        }

        [MenuItem("RTDK/Tools/Update Build Version", priority = 50)]
        public static void UpdateBuildVersion()
        {
            PlayerSettings.bundleVersion = Git.BuildVersion;
        }       

        public static void ClearLog()
        {
            var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
        }
    }

}