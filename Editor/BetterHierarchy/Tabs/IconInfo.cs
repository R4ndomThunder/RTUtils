/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System;
using UnityEditor;
using UnityEngine;

namespace RTDK.Editor.BetterHierarchy
{
    public struct IconInfo : IComparable<IconInfo>
    {
        public readonly string Name;
        public readonly Type Type;
        public readonly GUIContent Content;
        public readonly SerializedProperty Property;

        public IconInfo(ComponentType type, SerializedProperty property)
        {
            Name = type.Name;
            Type = type.Type;
            Content = type.Content;
            Property = property;
        }

        public int CompareTo(IconInfo other)
        {
            return Name.CompareTo(Name);
        }
    }

}