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
    [SerializeField] private GameObject dialogueBox121;
    [SerializeField] private GameObject dialogueBox122;
    [SerializeField] private GameObject dialogueBox131;
    [SerializeField] private GameObject dialogueBox132;
    [SerializeField] private GameObject dialogueBox141;
    [SerializeField] private GameObject dialogueBox142;
    [SerializeField] private GameObject dialogueBox151;
    [SerializeField] private GameObject dialogueBox152;
    [SerializeField] private GameObject dialogueBox16;

    [SerializeField] private GameObject dialogueBox21;
    [SerializeField] private GameObject dialogueBox221;
    [SerializeField] private GameObject dialogueBox222;
    [SerializeField] private GameObject dialogueBox231;
    [SerializeField] private GameObject dialogueBox232;
    [SerializeField] private GameObject dialogueBox241;
    [SerializeField] private GameObject dialogueBox242;
    [SerializeField] private GameObject dialogueBox251;
    [SerializeField] private GameObject dialogueBox252;
    [SerializeField] private GameObject dialogueBox26;

    [SerializeField] private GameObject dialogueBox31;
    [SerializeField] private GameObject dialogueBox321;
    [SerializeField] private GameObject dialogueBox322;
    [SerializeField] private GameObject dialogueBox331;
    [SerializeField] private GameObject dialogueBox332;
    [SerializeField] private GameObject dialogueBox341;
    [SerializeField] private GameObject dialogueBox342;
    [SerializeField] private GameObject dialogueBox351;
    [SerializeField] private GameObject dialogueBox352;
    [SerializeField] private GameObject dialogueBox36;

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

    [SerializeField] private GameObject dialogueBox51;
    [SerializeField] private GameObject dialogueBox521;
    [SerializeField] private GameObject dialogueBox522;
    [SerializeField] private GameObject dialogueBox531;
    [SerializeField] private GameObject dialogueBox532;
    [SerializeField] private GameObject dialogueBox541;
    [SerializeField] private GameObject dialogueBox542;
    [SerializeField] private GameObject dialogueBox551;
    [SerializeField] private GameObject dialogueBox552;
    [SerializeField] private GameObject dialogueBox56;


    [SerializeField] private bool isInDialogue;
    [SerializeField] private bool isClosingDialogue;


    [SerializeField] private GameObject Choice111;
    [SerializeField] private GameObject Choice112;
    [SerializeField] private GameObject Choice121;
    [SerializeField] private GameObject Choice122;
    [SerializeField] private GameObject Choice131;
    [SerializeField] private GameObject Choice132;
    [SerializeField] private GameObject Choice141;
    [SerializeField] private GameObject Choice142;
    [SerializeField] private GameObject Choice151;
    [SerializeField] private GameObject Choice152;

    [SerializeField] private GameObject Choice211;
    [SerializeField] private GameObject Choice212;
    [SerializeField] private GameObject Choice221;
    [SerializeField] private GameObject Choice222;
    [SerializeField] private GameObject Choice231;
    [SerializeField] private GameObject Choice232;
    [SerializeField] private GameObject Choice241;
    [SerializeField] private GameObject Choice242;
    [SerializeField] private GameObject Choice251;
    [SerializeField] private GameObject Choice252;

    [SerializeField] private GameObject Choice311;
    [SerializeField] private GameObject Choice312;
    [SerializeField] private GameObject Choice321;
    [SerializeField] private GameObject Choice322;
    [SerializeField] private GameObject Choice331;
    [SerializeField] private GameObject Choice332;
    [SerializeField] private GameObject Choice341;
    [SerializeField] private GameObject Choice342;
    [SerializeField] private GameObject Choice351;
    [SerializeField] private GameObject Choice352;

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

    [SerializeField] private GameObject Choice511;
    [SerializeField] private GameObject Choice512;
    [SerializeField] private GameObject Choice521;
    [SerializeField] private GameObject Choice522;
    [SerializeField] private GameObject Choice531;
    [SerializeField] private GameObject Choice532;
    [SerializeField] private GameObject Choice541;
    [SerializeField] private GameObject Choice542;
    [SerializeField] private GameObject Choice551;
    [SerializeField] private GameObject Choice552;


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

        if (dialogueBox222.activeInHierarchy == true || dialogueBox232.activeInHierarchy == true || dialogueBox241.activeInHierarchy == true || dialogueBox252.activeInHierarchy == true || dialogueBox26.activeInHierarchy == true || dialogueBox322.activeInHierarchy == true || dialogueBox332.activeInHierarchy == true || dialogueBox341.activeInHierarchy == true || dialogueBox352.activeInHierarchy == true || dialogueBox36.activeInHierarchy == true || dialogueBox422.activeInHierarchy == true || dialogueBox432.activeInHierarchy == true || dialogueBox441.activeInHierarchy == true || dialogueBox452.activeInHierarchy == true || dialogueBox46.activeInHierarchy == true || dialogueBox522.activeInHierarchy == true || dialogueBox532.activeInHierarchy == true || dialogueBox541.activeInHierarchy == true || dialogueBox552.activeInHierarchy == true || dialogueBox56.activeInHierarchy == true)

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

        dialogueBox222.SetActive(false);
        dialogueBox232.SetActive(false);
        dialogueBox241.SetActive(false);
        dialogueBox252.SetActive(false);

        dialogueBox322.SetActive(false);
        dialogueBox332.SetActive(false);
        dialogueBox341.SetActive(false);
        dialogueBox352.SetActive(false);

        dialogueBox422.SetActive(false);
        dialogueBox432.SetActive(false);
        dialogueBox441.SetActive(false);
        dialogueBox452.SetActive(false);

        dialogueBox522.SetActive(false);
        dialogueBox532.SetActive(false);
        dialogueBox541.SetActive(false);
        dialogueBox552.SetActive(false);

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
