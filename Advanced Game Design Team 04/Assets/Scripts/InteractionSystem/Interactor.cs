using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public PlayerControls playerControls;
    private PlayerInput playerInput;

    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private InteractionPromptUI interactionPromptUI;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    [SerializeField] private bool isInteracting;

    private GameObject _interactable;

    public void Interact (InputAction.CallbackContext context)
    {
        _interactable?.GetComponent<IInteractable>().Interact(this);

    }

    public void Cancel(InputAction.CallbackContext context)
    {       
        _interactable.GetComponent<ICancelable>().Cancel();

    }

    private void Update()
    {
      numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if (numFound > 0)
        {
            _interactable = colliders[0].gameObject;

            if (_interactable != null)
            {
                if (!interactionPromptUI.isDisplayed) interactionPromptUI.SetUp(_interactable.GetComponent<IInteractable>().InteractionPrompt);

            }
        }

        else
        {
            if (_interactable != null) _interactable = null;
            if (interactionPromptUI.isDisplayed) interactionPromptUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
