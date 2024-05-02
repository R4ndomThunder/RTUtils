/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.InspectorPlus
{
    public class DropdownAttribute : PropertyAttribute
    {
        public string CollectionName { get; private set; }

        /// <summary>
        /// Attribute to make a dropdown menu out of a collection of elements
        /// </summary>
        /// <param name="collectionName">The name of the array or list</param>
        public DropdownAttribute(string collectionName) => CollectionName = collectionName;
    }
}