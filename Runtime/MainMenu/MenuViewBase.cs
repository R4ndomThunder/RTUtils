/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;
using UnityEngine.EventSystems;

namespace RTDK.MainMenu
{
    public class MenuViewBase : MonoBehaviour
    {
        public GameObject firstSelected;

        public void OnEnable()
        {
            if (firstSelected != null)
            {
                EventSystem.current.SetSelectedGameObject(firstSelected);
            }
        }
    }
}