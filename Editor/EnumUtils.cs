/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System;

namespace RTDK.Editor
{
    /// <summary>
    /// C# enum utils
    /// </summary>
    public static class EnumUtils
    {

        /// <summary>
        /// Returns the name of the enumerator value
        /// </summary>
        /// <typeparam name="TEnum">Name of the enum class</typeparam>
        /// <param name="value">Enum value to retrieve the constant name</param>
        /// <returns>The name of the enum constant that the value representes</returns>
        public static string GetName<TEnum>(TEnum value)
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("Given value is not a valid enum");
            return Enum.GetName(typeof(TEnum), value);
        }

        /// <summary>
        /// Returns the name of the enumerator value, replacing the underscore with spaces
        /// </summary>
        /// <typeparam name="TEnum">Name of the enum class</typeparam>
        /// <param name="value">Enum value to retrieve the constant name</param>
        /// <returns>The name of the enum constant that the value representes, replacing the underscore with spaces</returns>
        public static string GetReadableName<TEnum>(TEnum value)
        {
            return GetName<TEnum>(value).Replace("_", " ");
        }

        /// <summary>
        /// Check if the enume
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static bool Exists<TEnum>(object value)
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("Given value is not a valid enum");
            return Enum.IsDefined(typeof(TEnum), value);
        }
    }
}