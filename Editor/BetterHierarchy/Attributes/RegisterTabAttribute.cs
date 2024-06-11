/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System;

namespace RTDK.Editor.BetterHierarchy
{
    public class RegisterTabAttribute : Attribute
    {
        public int priority = 0;

        public RegisterTabAttribute(int priority = 0)
        {
            this.priority = priority;
        }
    }
}