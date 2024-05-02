/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.InspectorPlus
{
    public class DisableInEditModeAttribute : PropertyAttribute
    {
        /// <summary>
		/// Attribute to disable a field when outside of play mode
		/// </summary>
        public DisableInEditModeAttribute()
#if UNITY_2023_3_OR_NEWER
        : base(true) 
#endif
        { }
    }
}