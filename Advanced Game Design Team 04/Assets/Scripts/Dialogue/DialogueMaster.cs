using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueMaster : MonoBehaviour
{

    private PlayerControls playerControls;
    private InputAction dialogue;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private bool isInDialogue;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    public void ActivateDialouge()
    {
        dialogueBox.SetActive(true);
    }

    void HandleDialouge(InputAction.CallbackContext context)
    {
        isInDialogue = !isInDialogue;

        if (isInDialogue)
        {
            ActivateDialouge();
        }

    }

    private void OnEnable()
    {
        dialogue = playerControls.Dialogue.Appear;
        dialogue.Enable();

        dialogue.performed += HandleDialouge;
    }
}
