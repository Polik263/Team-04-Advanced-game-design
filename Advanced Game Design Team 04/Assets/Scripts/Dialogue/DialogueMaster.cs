using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueMaster : MonoBehaviour
{

    private PlayerControls playerControls;
    private InputAction dialogue;

    [SerializeField] private GameObject panel;

   // [SerializeField] private Button button1;

   // public KeyCode key;


    [SerializeField] private GameObject dialogueBox11;
    [SerializeField] private GameObject dialogueBox12;
    [SerializeField] private GameObject dialogueBox13;
    [SerializeField] private GameObject dialogueBox14;
    [SerializeField] private GameObject dialogueBox15;
    [SerializeField] private GameObject dialogueBox21;
    [SerializeField] private GameObject dialogueBox31;
    [SerializeField] private bool isInDialogue;

    [SerializeField] private GameObject Choice11;
    [SerializeField] private GameObject Choice12;
    [SerializeField] private GameObject Choice13;
    [SerializeField] private GameObject Choice14;

    void Awake()
    {
        playerControls = new PlayerControls();

        //button1 = GetComponent<Button>();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(key))
    //    {
    //        button1.onClick.Invoke();
    //    }
    //}

    public void ActivateDialouge()
    {
        if (panel.activeInHierarchy == false)
        {
            panel.SetActive(true);
            dialogueBox11.SetActive(true);
        }
        if (dialogueBox11.activeInHierarchy == true)
        {
            Choice11.SetActive(true);
            Choice12.SetActive(true);
        }
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


    public void ChoiceOption11()
    {
        if (isInDialogue && dialogueBox11.activeInHierarchy == true)
        {
            dialogueBox11.SetActive(false);
            dialogueBox12.SetActive(true);

            Choice11.SetActive(false);
            Choice12.SetActive(false);

            Choice13.SetActive(true);
            Choice14.SetActive(true);
        }
    }

    public void ChoiceOption12()
    {
        if (isInDialogue)
        {
            dialogueBox11.SetActive(false);
            dialogueBox13.SetActive(true);

            Choice11.SetActive(false);
            Choice12.SetActive(false);
        }
    }

    public void ChoiceOption13()
    {
        if (isInDialogue)
        {
            dialogueBox12.SetActive(false);
            dialogueBox14.SetActive(true);

            Choice13.SetActive(false);
            Choice14.SetActive(false);
        }
    }

    public void ChoiceOption14()
    {
        if (isInDialogue)
        {
            dialogueBox12.SetActive(false);
            dialogueBox15.SetActive(true);

            Choice13.SetActive(false);
            Choice14.SetActive(false);
        }
    }
}
