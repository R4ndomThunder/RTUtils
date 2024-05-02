/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.InspectorPlus
{
    public class FolderPathAttribute : PropertyAttribute
    {
        public bool GetRelativePath { get; private set; }

        /// <summary>
        /// Attribute to get the path of a folder
        /// </summary>
        /// <param name="getRelativePath">Get the relative path of the folder</param>
        public FolderPathAttribute(bool getRelativePath = true) => GetRelativePath = getRelativePath;
    }
}