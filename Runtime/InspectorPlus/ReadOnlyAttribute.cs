/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.InspectorPlus
{
    /// <summary>
    /// Attribute to make a field readonly in the inspector
    /// </summary>
    public class ReadOnlyAttribute : PropertyAttribute
    {
        public ReadOnlyAttribute()
#if UNITY_2023_3_OR_NEWER
        : base(true) 
#endif
        {

        }
    }
}