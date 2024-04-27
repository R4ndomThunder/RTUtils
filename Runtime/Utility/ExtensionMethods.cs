/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.Utility
{
    public static class ExtensionMethods
    {
        public static float Map(this float value, float fromMin, float fromMax, float toMin, float toMax) => toMin + (value - fromMin) * (toMax - toMin) / (fromMax - fromMin);
        public static float Map(this int value, int fromMin, int fromMax, int toMin, int toMax) => toMin + (value - fromMin) * (toMax - toMin) / (fromMax - fromMin);

        public static bool IsNotFilled(this string str) => str.IsNullOrEmpty() && str.IsNullOrWhiteSpace();
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);
        public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);
    }
}