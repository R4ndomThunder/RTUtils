/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using RTDK.InteractionSystem;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class SampleInteraction : MonoBehaviour, IInteractable
{
    [field:SerializeField]
    private string InteractionText { get; set; }

    public string GetInteractText()
    {
        return InteractionText;
    }

    public Transform GetNearestPoint()
    {
        return null;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform transform)
    {
        Debug.Log($"Interacted successfully with {transform.name}");
    }
}
