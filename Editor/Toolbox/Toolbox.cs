/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RTDK.Editor.Toolbox
{
    /// <summary>
    /// 
    /// </summary>
    public class Toolbox
    {
        [MenuItem("RTDK/Tools/Generate Project Folders", priority = 10, secondaryPriority = 20)]
        public static void GenerateProjectFolders()
        {
            var projectFolders = new List<string>
            {
                 $"{Application.dataPath}/_Project",
                 $"{Application.dataPath}/_Project/Audio",
                 $"{Application.dataPath}/_Project/Data",
                 $"{Application.dataPath}/_Project/Images",
                 $"{Application.dataPath}/_Project/Materials",
                 $"{Application.dataPath}/_Project/Models",
                 $"{Application.dataPath}/_Project/Prefabs",
                 $"{Application.dataPath}/_Project/Scenes",
                 $"{Application.dataPath}/_Project/Scripts",
                 $"{Application.dataPath}/_Project/Settings",
                 $"{Application.dataPath}/_Project/Shaders",
                 $"{Application.dataPath}/_Project/Textures",
                 $"{Application.dataPath}/Screenshots",
            };

            foreach (var folder in projectFolders)
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                    Debug.Log($"[GenerateProjectFolders] ~ {folder} created.");
                }
                else
                {
                    Debug.Log($"[GenerateProjectFolders] ~ {folder} already exists.");
                }
            }
        }


        [MenuItem("RTDK/Tools/Update Build Version", priority = 50)]
        public static void UpdateBuildVersion()
        {
            PlayerSettings.bundleVersion = Git.BuildVersion;
        }

        [MenuItem("RTDK/Take Screenshot", priority = 30)]
        public static void CaptureScreenshot()
        {
            var screenpath = $"{Application.dataPath}/Screenshots";

            if (!Directory.Exists(screenpath))
            {
                Directory.CreateDirectory(screenpath);
            }

            ScreenCapture.CaptureScreenshot($"{screenpath + "/" + SceneManager.GetActiveScene().name}-{DateTime.Now:dd-MM-yyyy-hh-mm-ss-fff}.png");
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