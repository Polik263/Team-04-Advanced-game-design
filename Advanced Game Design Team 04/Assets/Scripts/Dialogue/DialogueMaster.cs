using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueMaster : MonoBehaviour
{
    //public GameObject[] lines;
    //public int linesNumber;
    //public int linesCount = 0;

    [SerializeField] private GameObject startDialogue;


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


    [SerializeField] private GameObject dialogueBox41;
    [SerializeField] private GameObject dialogueBox421;
    [SerializeField] private GameObject dialogueBox422;
    [SerializeField] private GameObject dialogueBox431;
    [SerializeField] private GameObject dialogueBox432;
    [SerializeField] private GameObject dialogueBox441;
    [SerializeField] private GameObject dialogueBox442;
    [SerializeField] private GameObject dialogueBox451;
    [SerializeField] private GameObject dialogueBox452;
    [SerializeField] private GameObject dialogueBox46;


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
    [SerializeField] private GameObject Choice411;
    [SerializeField] private GameObject Choice412;
    [SerializeField] private GameObject Choice421;
    [SerializeField] private GameObject Choice422;
    [SerializeField] private GameObject Choice431;
    [SerializeField] private GameObject Choice432;
    [SerializeField] private GameObject Choice441;
    [SerializeField] private GameObject Choice442;
    [SerializeField] private GameObject Choice451;
    [SerializeField] private GameObject Choice452;


    // public Animator animator;

    void Awake()
    {
        playerControls = new PlayerControls();
    }


    private void Update()
    {
        if (panel.activeInHierarchy == true)
        {
            //animator.SetBool("IsOpen", true);
            isInDialogue = true;
        }

        if (dialogueBox422.activeInHierarchy == true || dialogueBox432.activeInHierarchy == true || dialogueBox441.activeInHierarchy == true || dialogueBox452.activeInHierarchy == true || dialogueBox46.activeInHierarchy == true)
        {
            if (isClosingDialogue == false)
            {
                StartCoroutine(CloseDialogues());
                Debug.Log("Preparing to close dialogue!");

            }
            //Invoke("CloseDialogue", 5.0f);
        }


    }

    void CloseDialogue()
    {
        Debug.Log("Deactivating Dialogue");
        //animator.SetBool("IsOpen", false);
        panel.SetActive(false);
        dialogueBox13.SetActive(false);
        dialogueBox23.SetActive(false);
        dialogueBox33.SetActive(false);
        dialogueBox422.SetActive(false);
        dialogueBox432.SetActive(false);
        dialogueBox441.SetActive(false);
        dialogueBox452.SetActive(false);
        isInDialogue = false;
        isClosingDialogue = false;
    }



    IEnumerator CloseDialogues()
    {
        isClosingDialogue = true;

        yield return new WaitForSeconds(20);
        CloseDialogue();
    }

    IEnumerator ActivateOptions()
    {
        yield return new WaitForSeconds(20);
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

        if (dialogueBox12.activeInHierarchy == true)

        {
            Choice13.SetActive(true);
            Choice14.SetActive(true);
        }

        if (dialogueBox41.activeInHierarchy == true)
        {
            Choice411.SetActive(true);
            Choice412.SetActive(true);
            //StartCoroutine(ActivateOptions());
        }

        if (dialogueBox421.activeInHierarchy == true)
        {
            Choice421.SetActive(true);
            Choice422.SetActive(true);
            //StartCoroutine(ActivateOptions());
        }

        if (dialogueBox431.activeInHierarchy == true)
        {
            Choice431.SetActive(true);
            Choice432.SetActive(true);
        }

        if (dialogueBox442.activeInHierarchy == true)
        {
            Choice441.SetActive(true);
            Choice442.SetActive(true);
        }

        if (dialogueBox451.activeInHierarchy == true)
        {
            Choice451.SetActive(true);
            Choice452.SetActive(true);
        }
    }


    public void ActivateDialouge()
    {


        if (panel.activeInHierarchy == false)
        {
            isInDialogue = false;
            panel.SetActive(true);

            //linesNumber = Random.Range(0, 3);
            //linesCount = 0;
            //while (linesCount < 3)
            //{
            //    lines[linesCount].SetActive(false);
            //    linesCount += 1;
            //}
            //lines[linesNumber].SetActive(true);

            startDialogue.SetActive(true);

            // StartCoroutine(ActivateOptions());
        }

        if (dialogueBox41.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox421.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox431.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox442.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox451.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
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

        StartCoroutine(ActivateOptions());

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

    public void ChoiceOption411()
    {


        dialogueBox41.SetActive(false);
        dialogueBox421.SetActive(true);

        Choice411.SetActive(false);
        Choice412.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption412()
    {


        dialogueBox41.SetActive(false);
        dialogueBox422.SetActive(true);

        Choice411.SetActive(false);
        Choice412.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption421()
    {
        dialogueBox421.SetActive(false);
        dialogueBox431.SetActive(true);

        Choice421.SetActive(false);
        Choice422.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption422()
    {
        dialogueBox421.SetActive(false);
        dialogueBox432.SetActive(true);

        Choice421.SetActive(false);
        Choice422.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption431()
    {
        dialogueBox431.SetActive(false);
        dialogueBox441.SetActive(true);

        Choice431.SetActive(false);
        Choice432.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption432()
    {
        dialogueBox431.SetActive(false);
        dialogueBox442.SetActive(true);

        Choice431.SetActive(false);
        Choice432.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption441()
    {
        dialogueBox442.SetActive(false);
        dialogueBox451.SetActive(true);

        Choice441.SetActive(false);
        Choice442.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption442()
    {
        dialogueBox442.SetActive(false);
        dialogueBox452.SetActive(true);

        Choice441.SetActive(false);
        Choice442.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption451()
    {
        dialogueBox451.SetActive(false);
        dialogueBox46.SetActive(true);

        Choice451.SetActive(false);
        Choice452.SetActive(false);

        StartCoroutine(ActivateOptions());
    }
}
