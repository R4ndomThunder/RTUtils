/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.InspectorPlus
{
    public class HideInPlayModeAttribute : PropertyAttribute
    {
        /// <summary>
        /// Attribute to hide a field when entering play mode
        /// </summary>
        public HideInPlayModeAttribute()
#if UNITY_2023_3_OR_NEWER
        : base(true) 
#endif
        { }
    }
}