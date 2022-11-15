using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeWeapon : MonoBehaviour
{
    private PlayerControls playerControls;
    private InputAction dialogue;


    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private bool isInDialogue;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        dialogue = playerControls.Dialogue.Appear;
        dialogue.Enable();

        dialogue.performed += HandleDialouge;
    }

    private void OnDisable()
    {
        dialogue.Disable();
    }

    void HandleDialouge(InputAction.CallbackContext context) 
    {
        isInDialogue = !isInDialogue;

        if(isInDialogue)
        {
            ActivateDialouge();
        }

        else
        {
            DeactivateDialouge();
        }
    }

    public void ActivateDialouge()
    {
        dialogueBox.SetActive(true);
    }

    public void DeactivateDialouge()
    {
        dialogueBox.SetActive(false);
        isInDialogue = false;
    }
}
