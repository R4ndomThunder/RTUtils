/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using TMPro;
using UnityEngine;

namespace RTDK.InteractionSystem
{
    /// <summary>
    /// Shows a banner with the name or text of the interactable is in range
    /// </summary>
    public class InteractionPopup : MonoBehaviour
    {
        [SerializeField] private Interacter interacter;
        [SerializeField] private GameObject popupContainer;
        [SerializeField] private TextMeshProUGUI popupText;

        private void Start()
        {
            interacter = FindObjectOfType<Interacter>();
        }

        private void Update()
        {
            if (!interacter) return;

            if (interacter.GetNearestInteractable(out IInteractable inter))
            {
                ShowPopup(inter);
                return;
            }

            if (popupContainer.activeSelf)
                HidePopup();
        }

        void ShowPopup(IInteractable interactable)
        {
            popupContainer.SetActive(true);
            popupText.text = $"{interactable.GetInteractText()}";
        }

        void HidePopup()
        {
            popupContainer.SetActive(false);
        }
    }

}