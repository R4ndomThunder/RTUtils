/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.InspectorPlus
{
    public enum StringInputMode
    {
        Constant,
        Dynamic
    }

    public interface IDynamicStringAttribute
    {
        public StringInputMode StringInputMode { get; }
    }
}