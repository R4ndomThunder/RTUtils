/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/


namespace RTDK.InteractionSystem
{
    using UnityEngine;

    public interface IInteractable
    {
        void Interact(Transform transform);
        string GetInteractText();
        Transform GetTransform();
        Transform GetNearestPoint();
    }

}