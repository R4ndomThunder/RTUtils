/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace RTDK.InteractionSystem
{
    /// <summary>
    /// The object that goes to the player, it check if there's interactable objects in range.
    /// </summary>
    public class Interacter : MonoBehaviour
    {
        [SerializeField]
        private float interactionRange = 4.0f;

        [SerializeField]
        internal InputActionReference interactionInput;

        private void Awake()
        {
            interactionInput.action.performed += OnInteract;
        }

        private void OnDestroy()
        {
            interactionInput.action.performed -= OnInteract;
        }

        void OnInteract(CallbackContext ctx)
        {
            if (ctx.action.WasPressedThisFrame())
                CheckInteraction();
        }

        void CheckInteraction()
        {
            if (GetNearestInteractable(out IInteractable nearestInteractable))
            {
                nearestInteractable.Interact(transform);
            }
        }

        public List<IInteractable> GetInteractableObjects()
        {
            List<IInteractable> interactables = new List<IInteractable>();
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRange);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    interactables.Add(interactable);
                }
            }

            return interactables;
        }

        public bool GetNearestInteractable(out IInteractable nearestInteractable)
        {
            var interactables = GetInteractableObjects();
            var orderedByDistance = interactables.OrderBy(x => Vector3.Distance(x.GetTransform().position, transform.position));
            nearestInteractable = orderedByDistance.FirstOrDefault();
            return nearestInteractable != null;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, interactionRange);
        }
    }
}