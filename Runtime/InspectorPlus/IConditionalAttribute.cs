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
    /// 
    /// </summary>
    public interface IConditionalAttribute
    {
        public string ConditionName { get; }
        public int EnumValue { get; }
    }

}