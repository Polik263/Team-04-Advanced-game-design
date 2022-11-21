using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueMaster : MonoBehaviour
{
    public GameObject[] lines;
    public int linesNumber;
    public int linesCount = 0;


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
    [SerializeField] private GameObject dialogueBox22;
    [SerializeField] private GameObject dialogueBox23;
    [SerializeField] private GameObject dialogueBox31;
    [SerializeField] private GameObject dialogueBox32;
    [SerializeField] private GameObject dialogueBox33;
    [SerializeField] private bool isInDialogue;
    [SerializeField] private bool isClosingDialogue;

    [SerializeField] private GameObject Choice11;
    [SerializeField] private GameObject Choice12;
    [SerializeField] private GameObject Choice13;
    [SerializeField] private GameObject Choice14;
    [SerializeField] private GameObject Choice21;
    [SerializeField] private GameObject Choice22;
    [SerializeField] private GameObject Choice31;
    [SerializeField] private GameObject Choice32;


    public Animator animator;

    void Awake()
    {
        playerControls = new PlayerControls();
    }


    private void Update()
    {
        if (panel.activeInHierarchy == true)
        {
            animator.SetBool("IsOpen", true);
            isInDialogue = true;
        }

        if (dialogueBox33.activeInHierarchy == true || dialogueBox23.activeInHierarchy == true || dialogueBox13.activeInHierarchy == true)
        {
            if (isClosingDialogue == false)
            {
                StartCoroutine(CloseDialogues());
                Debug.Log("Preparing to close dialogue!");

            }
            //Invoke("CloseDialogue", 5.0f);
        }

        StartCoroutine(ActivateOptions());
    }

    void CloseDialogue()
    {
        Debug.Log("Deactivating Dialogue");
        animator.SetBool("IsOpen", false);
        panel.SetActive(false);
        dialogueBox13.SetActive(false);
        dialogueBox23.SetActive(false);
        dialogueBox33.SetActive(false);
        isInDialogue = false;
        isClosingDialogue = false;
    }


        
    IEnumerator CloseDialogues () 
    {
        isClosingDialogue = true;

        yield return new WaitForSeconds(10);
        CloseDialogue();
    }

    IEnumerator ActivateOptions()
    {
        yield return new WaitForSeconds(5);
        if (dialogueBox11.activeInHierarchy == true)
        {
            Choice11.SetActive(true);
            Choice12.SetActive(true);
        }

        if (dialogueBox21.activeInHierarchy == true)
        {
           Choice21.SetActive(true);
           Choice22.SetActive(true);
        }
        
        if (dialogueBox31.activeInHierarchy == true)
        {
            Choice31.SetActive(true);
            Choice32.SetActive(true);
        }
    }


    public void ActivateDialouge()
    {
        

        if (panel.activeInHierarchy == false)
        {
            isInDialogue = false;
            panel.SetActive(true);

            linesNumber = Random.Range(0, 3);
            linesCount = 0;
            while (linesCount < 3)
            {
                lines[linesCount].SetActive(false);
                linesCount += 1;
            }
            lines[linesNumber].SetActive(true);
        }


        //if (dialogueBox11.activeInHierarchy == true)
        //{
        //    Choice11.SetActive(true);
        //    Choice12.SetActive(true);
        //}

        //if (dialogueBox21.activeInHierarchy == true)
        //{
        //    Choice21.SetActive(true);
        //    Choice22.SetActive(true);
        //}

        //if (dialogueBox31.activeInHierarchy == true)
        //{
        //    Choice31.SetActive(true);
        //    Choice32.SetActive(true);
        //}
    }

    void HandleDialouge(InputAction.CallbackContext context)
    {

        isInDialogue = !isInDialogue;
        Debug.Log("We were at " + !isInDialogue + " and now at " + isInDialogue);

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
        //Debug.Log(dialogue);
    }

    private void OnDisable()
    {
        dialogue.performed -= HandleDialouge;

    }


    public void ChoiceOption11()
    {
       
        
            dialogueBox11.SetActive(false);
            dialogueBox12.SetActive(true);

            Choice11.SetActive(false);
            Choice12.SetActive(false);

            Choice13.SetActive(true);
            Choice14.SetActive(true);
        
    }

    public void ChoiceOption12()
    {
       
        
            dialogueBox11.SetActive(false);
            dialogueBox13.SetActive(true);

            Choice11.SetActive(false);
            Choice12.SetActive(false);
        
    }

    public void ChoiceOption13()
    {
       
        
            dialogueBox12.SetActive(false);
            dialogueBox14.SetActive(true);

            Choice13.SetActive(false);
            Choice14.SetActive(false);
        
    }

    public void ChoiceOption14()
    {
       
        
            dialogueBox12.SetActive(false);
            dialogueBox15.SetActive(true);

            Choice13.SetActive(false);
            Choice14.SetActive(false);
        
    }

    public void ChoiceOption21() 
    {
      
        
            dialogueBox21.SetActive(false);
            dialogueBox22.SetActive(true);

            Choice21.SetActive(false);
            Choice22.SetActive(false);

            //Choice23.SetActive(true);
            //Choice24.SetActive(true);
        
    }

    public void ChoiceOption22()
    {
      
        
            dialogueBox21.SetActive(false);
            dialogueBox23.SetActive(true);

            Choice21.SetActive(false);
            Choice22.SetActive(false);
        
    }

    public void ChoiceOption31()
    {
        
        
            dialogueBox31.SetActive(false);
            dialogueBox32.SetActive(true);

            Choice31.SetActive(false);
            Choice32.SetActive(false);

            //Choice23.SetActive(true);
            //Choice24.SetActive(true);
        
    }

    public void ChoiceOption32()
    {
      
        
            dialogueBox31.SetActive(false);
            dialogueBox33.SetActive(true);

            Choice31.SetActive(false);
            Choice32.SetActive(false);
        
    }
}
