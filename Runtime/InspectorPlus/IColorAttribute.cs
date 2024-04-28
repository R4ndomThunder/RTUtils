/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

namespace RTDK.InspectorPlus
{
    public interface IColorAttribute
    {
        public float R { get; }
        public float G { get; }
        public float B { get; }
        public bool UseRGB { get; }
        public string HexColor { get; }

        public GUIColor Color { get; }
    }

}