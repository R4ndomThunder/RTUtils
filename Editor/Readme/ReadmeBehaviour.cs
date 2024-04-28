/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.Editor.Readme
{
    [AddComponentMenu("Readme")]
    public class ReadmeBehaviour : MonoBehaviour
    {
        public Readme readme;

        [HideInInspector]
        public bool showIconInHierarchy = true;
    }
}