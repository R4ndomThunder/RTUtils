/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.InspectorPlus
{
    public class DisableFieldAttribute : PropertyAttribute, IConditionalAttribute
    {
        public string ConditionName { get; private set; }
        public int EnumValue { get; private set; }

        /// <summary>
        /// Attribute to disable a field based on a condition
        /// </summary>
        /// <param name="conditionName">The name of the condition to evaluate</param>
        public DisableFieldAttribute(string conditionName)
#if UNITY_2023_3_OR_NEWER
        : base(true) 
#endif
            => ConditionName = conditionName;

        /// <summary>
        /// Attribute to disable a field based on a condition
        /// </summary>
        /// <param name="conditionName">The name of the condition to evaluate</param>
        /// <param name="enumValue">The value of the enum condition</param>
        public DisableFieldAttribute(string conditionName, object enumValue)
#if UNITY_2023_3_OR_NEWER
        : base(true) 
#endif
        {
            ConditionName = conditionName;
            EnumValue = (int)enumValue;
        }
    }
}