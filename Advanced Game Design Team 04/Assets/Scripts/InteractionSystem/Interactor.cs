using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private UIPrompt interactablePrompt;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    private IInteractable interactable1;

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if (numFound > 0)
        {
            interactable1 = colliders[0].GetComponent<IInteractable>();

            if (interactable1 != null)
            {
                if (interactablePrompt.IsDisplayed) interactablePrompt.SetUp(interactable1.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame) interactable1.Interact(this);
            }
            else
            {
                if (interactable1 != null) interactable1 = null;
                if (interactablePrompt.IsDisplayed) interactablePrompt.Close();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
