/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System;

namespace RTDK.Editor.BetterHierarchy
{
    public enum FilterType { NONE, NAME, TYPE }

    public struct CategoryFilter
    {
        public readonly string Name;
        public readonly string Filter;
        public readonly FilterType FilterType;

        public CategoryFilter(string name, string filter, FilterType filterType)
        {
            this.Name = name;
            this.Filter = filter;
            this.FilterType = filterType;
        }

        public bool IsValidFilter(Type type)
        {
            switch (FilterType)
            {
                case FilterType.NONE:
                    return false;

                case FilterType.NAME:
                    return type.FullName.Contains(Filter);

                case FilterType.TYPE:
                    Type baseType = Type.GetType(Filter);
                    return type.IsAssignableFrom(baseType) || type.IsSubclassOf(baseType);
            }

            return false;
        }
    }
}