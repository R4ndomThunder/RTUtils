/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System;
using UnityEditor;
using UnityEngine;

namespace RTDK.Editor.BetterFolders
{
    [CreateAssetMenu(fileName = "Folder Icon Manager", menuName = "Scriptables Objects/Folder Manager")]
    public class FolderIconSettings : ScriptableObject
    {
        [Serializable]
        public class FolderIcon
        {
            public DefaultAsset folder;

            public Texture2D folderIcon;
            public Texture2D overlayIcon;
        }

        //Global Settings
        public bool showOverlay = true;

        public bool showCustomFolder = true;

        public FolderIcon[] icons = new FolderIcon[0];
    }
}