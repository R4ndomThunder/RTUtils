/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.InspectorPlus
{
    public class DisableInPlayModeAttribute : PropertyAttribute
    {
        /// <summary>
        /// Attribute to disable a field when entering play mode
        /// </summary>
        public DisableInPlayModeAttribute()
#if UNITY_2023_3_OR_NEWER
        : base(true) 
#endif
        { }
    }
}