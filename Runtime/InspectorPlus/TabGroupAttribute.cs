/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.InspectorPlus
{
    public class TabGroupAttribute : PropertyAttribute
    {
        public string[] FieldsToGroup { get; private set; }

        /// <summary>
        /// Attribute to display specified fields in a tabbed group
        /// </summary>
        /// <param name="fieldsToGroup">The name of the fields to group</param>
        public TabGroupAttribute(params string[] fieldsToGroup) => FieldsToGroup = fieldsToGroup;
    }
}