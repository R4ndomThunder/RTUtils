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
    public class ButtonFieldAttribute : PropertyAttribute
    {
        public string FunctionName { get; private set; }
        public string Label { get; private set; }   
        public float Height { get; private set; }

        /// <summary>
		/// Attribute to add a button in the inspector in place of a field
		/// </summary>
		/// <param name="functionName">The name of the function to call</param>
		/// <param name="buttonLabel">The label displayed on the button</param>
		/// <param name="buttonHeight">The height of the button in pixels</param>
		public ButtonFieldAttribute(string functionName, string buttonLabel = "", float buttonHeight = 18f)
        {
            FunctionName = functionName;
            Label = buttonLabel;
            Height = buttonHeight;
        }
    }
}