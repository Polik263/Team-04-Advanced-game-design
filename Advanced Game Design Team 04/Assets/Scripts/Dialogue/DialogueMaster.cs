using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.ExceptionServices;

public class DialogueMaster : MonoBehaviour
{
    //public GameObject[] lines;
    //public int linesNumber;
    //public int linesCount = 0;

    [SerializeField] private GameObject startDialogue;

    [SerializeField] private GameObject panel;

    // [SerializeField] private Button button1;

    // public KeyCode key;
    public float dialogueDuration = 21;
    public float optionSpawn = 21;
    public float dialogueReopen = 25;


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
    [SerializeField] private GameObject dialogueBox25;

    [SerializeField] private GameObject dialogueBox31;
    [SerializeField] private GameObject dialogueBox321;
    [SerializeField] private GameObject dialogueBox322;
    [SerializeField] private GameObject dialogueBox331;
    [SerializeField] private GameObject dialogueBox332;
    [SerializeField] private GameObject dialogueBox341;
    [SerializeField] private GameObject dialogueBox342;
    [SerializeField] private GameObject dialogueBox35;

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

    [SerializeField] private GameObject dialogueBox61;
    [SerializeField] private GameObject dialogueBox621;
    [SerializeField] private GameObject dialogueBox622;
    [SerializeField] private GameObject dialogueBox631;
    [SerializeField] private GameObject dialogueBox632;
    [SerializeField] private GameObject dialogueBox641;
    [SerializeField] private GameObject dialogueBox642;
    [SerializeField] private GameObject dialogueBox651;
    [SerializeField] private GameObject dialogueBox652;
    [SerializeField] private GameObject dialogueBox66;

    [SerializeField] private GameObject dialogueBox71;
    [SerializeField] private GameObject dialogueBox721;
    [SerializeField] private GameObject dialogueBox722;
    [SerializeField] private GameObject dialogueBox731;
    [SerializeField] private GameObject dialogueBox732;
    [SerializeField] private GameObject dialogueBox741;
    [SerializeField] private GameObject dialogueBox742;
    [SerializeField] private GameObject dialogueBox751;
    [SerializeField] private GameObject dialogueBox752;
    [SerializeField] private GameObject dialogueBox76;


    public bool isInDialogue;
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

    [SerializeField] private GameObject Choice311;
    [SerializeField] private GameObject Choice312;
    [SerializeField] private GameObject Choice321;
    [SerializeField] private GameObject Choice322;
    [SerializeField] private GameObject Choice331;
    [SerializeField] private GameObject Choice332;
    [SerializeField] private GameObject Choice341;
    [SerializeField] private GameObject Choice342;

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

    [SerializeField] private GameObject Choice611;
    [SerializeField] private GameObject Choice612;
    [SerializeField] private GameObject Choice621;
    [SerializeField] private GameObject Choice622;
    [SerializeField] private GameObject Choice631;
    [SerializeField] private GameObject Choice632;
    [SerializeField] private GameObject Choice641;
    [SerializeField] private GameObject Choice642;
    [SerializeField] private GameObject Choice651;
    [SerializeField] private GameObject Choice652;

    [SerializeField] private GameObject Choice711;
    [SerializeField] private GameObject Choice712;
    [SerializeField] private GameObject Choice721;
    [SerializeField] private GameObject Choice722;
    [SerializeField] private GameObject Choice731;
    [SerializeField] private GameObject Choice732;
    [SerializeField] private GameObject Choice741;
    [SerializeField] private GameObject Choice742;
    [SerializeField] private GameObject Choice751;
    [SerializeField] private GameObject Choice752;

    public bool gotSlam;
    public bool gotHeal;
    public bool gotReflect;
    public bool gotLightDash;
    public bool gotDamage;
    public bool gotDarkExtension;


    // public Animator animator;


    private void Start()
    {
        StartCoroutine(ActivateDialouge());
    }


    private void Update()
    {
        if (panel.activeInHierarchy == true)
        {
            //animator.SetBool("IsOpen", true);
            isInDialogue = true;
        }

        if (dialogueBox232.activeInHierarchy == true || dialogueBox241.activeInHierarchy == true || dialogueBox25.activeInHierarchy == true)
        {
            gotHeal = true;        
        }

        if (dialogueBox332.activeInHierarchy == true || dialogueBox341.activeInHierarchy == true || dialogueBox35.activeInHierarchy == true)
        {
            gotDamage = true;
        }

        if (dialogueBox432.activeInHierarchy == true || dialogueBox441.activeInHierarchy == true || dialogueBox452.activeInHierarchy == true || dialogueBox46.activeInHierarchy == true)
        {
            gotLightDash = true;
        }

        if (dialogueBox532.activeInHierarchy == true || dialogueBox541.activeInHierarchy == true || dialogueBox552.activeInHierarchy == true || dialogueBox56.activeInHierarchy == true)
        {
            gotDarkExtension = true;
        }

        if (dialogueBox632.activeInHierarchy == true || dialogueBox641.activeInHierarchy == true || dialogueBox652.activeInHierarchy == true || dialogueBox66.activeInHierarchy == true)
        {
            gotReflect = true;
        }

        if (dialogueBox732.activeInHierarchy == true || dialogueBox741.activeInHierarchy == true || dialogueBox752.activeInHierarchy == true || dialogueBox76.activeInHierarchy == true)
        {
            gotSlam = true;
        }

        if (gotSlam == true)
        {
            gotSlam = true;
        }

        if (gotHeal == true)
        {
            gotHeal = true;
        }

        if (gotReflect == true)
        {
            gotReflect = true;
        }

        if (gotLightDash == true)
        {
            gotLightDash = true;
        }

        if (gotDamage == true)
        {
            gotDamage = true;
        }

        if (dialogueBox222.activeInHierarchy == true || dialogueBox232.activeInHierarchy == true || dialogueBox241.activeInHierarchy == true || dialogueBox25.activeInHierarchy == true || dialogueBox322.activeInHierarchy == true || dialogueBox332.activeInHierarchy == true || dialogueBox341.activeInHierarchy == true || dialogueBox35.activeInHierarchy == true || dialogueBox422.activeInHierarchy == true || dialogueBox432.activeInHierarchy == true || dialogueBox441.activeInHierarchy == true || dialogueBox452.activeInHierarchy == true || dialogueBox46.activeInHierarchy == true || dialogueBox522.activeInHierarchy == true || dialogueBox532.activeInHierarchy == true || dialogueBox541.activeInHierarchy == true || dialogueBox552.activeInHierarchy == true || dialogueBox56.activeInHierarchy == true || dialogueBox622.activeInHierarchy == true || dialogueBox632.activeInHierarchy == true || dialogueBox641.activeInHierarchy == true || dialogueBox652.activeInHierarchy == true || dialogueBox66.activeInHierarchy == true || dialogueBox722.activeInHierarchy == true || dialogueBox732.activeInHierarchy == true || dialogueBox741.activeInHierarchy == true || dialogueBox752.activeInHierarchy == true || dialogueBox76.activeInHierarchy == true)

        {
            if (isClosingDialogue == false)
            {
                StartCoroutine(CloseDialogues());
                Debug.Log("Preparing to close dialogue!");

            }
            //Invoke("CloseDialogue", 5.0f);
        }

        if (dialogueBox11.activeInHierarchy == true)
        {
            StartCoroutine(FirstDialogue());
        }

        if (dialogueBox322.activeInHierarchy == true || dialogueBox222.activeInHierarchy == true || dialogueBox422.activeInHierarchy == true || dialogueBox522.activeInHierarchy == true || dialogueBox622.activeInHierarchy == true || dialogueBox722.activeInHierarchy == true)
        {
            StartCoroutine(ReopenDialogue());
            
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
        dialogueBox25.SetActive(false);

        dialogueBox322.SetActive(false);
        dialogueBox332.SetActive(false);
        dialogueBox341.SetActive(false);
        dialogueBox35.SetActive(false);

        dialogueBox422.SetActive(false);
        dialogueBox432.SetActive(false);
        dialogueBox441.SetActive(false);
        dialogueBox452.SetActive(false);
        dialogueBox46.SetActive(false);

        dialogueBox522.SetActive(false);
        dialogueBox532.SetActive(false);
        dialogueBox541.SetActive(false);
        dialogueBox552.SetActive(false);
        dialogueBox56.SetActive(false);

        dialogueBox622.SetActive(false);
        dialogueBox632.SetActive(false);
        dialogueBox641.SetActive(false);
        dialogueBox652.SetActive(false);
        dialogueBox66.SetActive(false);

        dialogueBox722.SetActive(false);
        dialogueBox732.SetActive(false);
        dialogueBox741.SetActive(false);
        dialogueBox752.SetActive(false);
        dialogueBox76.SetActive(false);

        isInDialogue = false;
        isClosingDialogue = false;
    }

    void FirstLine()
    {
        
        
            dialogueBox11.SetActive(false);
            dialogueBox121.SetActive(true);

    }

    void SecondLine()
    {
        if(dialogueBox121.activeInHierarchy == true)
        {
            dialogueBox121.SetActive(false);
            dialogueBox122.SetActive(true);
        }
    }



    IEnumerator FirstDialogue()
    {
        isClosingDialogue = true;

        yield return new WaitForSeconds(5);
        FirstLine ();
        yield return new WaitForSeconds(5);
        SecondLine();

    }



    IEnumerator CloseDialogues()
    {
        isClosingDialogue = true;

        yield return new WaitForSeconds(dialogueDuration);
        CloseDialogue();
    }

    IEnumerator ActivateOptions()
    {
        yield return new WaitForSeconds(optionSpawn);


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

        if (dialogueBox21.activeInHierarchy == true)
        {
            Choice211.SetActive(true);
            Choice212.SetActive(true);
            //StartCoroutine(ActivateOptions());
        }

        if (dialogueBox221.activeInHierarchy == true)
        {
            Choice221.SetActive(true);
            Choice222.SetActive(true);
            //StartCoroutine(ActivateOptions());
        }

        if (dialogueBox231.activeInHierarchy == true)
        {
            Choice231.SetActive(true);
            Choice232.SetActive(true);
        }

        if (dialogueBox242.activeInHierarchy == true)
        {
            Choice241.SetActive(true);
            Choice242.SetActive(true);
        }

        if (dialogueBox31.activeInHierarchy == true)
        {
            Choice311.SetActive(true);
            Choice312.SetActive(true);
            //StartCoroutine(ActivateOptions());
        }

        if (dialogueBox321.activeInHierarchy == true)
        {
            Choice321.SetActive(true);
            Choice322.SetActive(true);
            //StartCoroutine(ActivateOptions());
        }

        if (dialogueBox331.activeInHierarchy == true)
        {
            Choice331.SetActive(true);
            Choice332.SetActive(true);
        }

        if (dialogueBox342.activeInHierarchy == true)
        {
            Choice341.SetActive(true);
            Choice342.SetActive(true);
        }

        if (dialogueBox51.activeInHierarchy == true)
        {
            Choice511.SetActive(true);
            Choice512.SetActive(true);
            //StartCoroutine(ActivateOptions());
        }

        if (dialogueBox521.activeInHierarchy == true)
        {
            Choice521.SetActive(true);
            Choice522.SetActive(true);
            //StartCoroutine(ActivateOptions());
        }

        if (dialogueBox531.activeInHierarchy == true)
        {
            Choice531.SetActive(true);
            Choice532.SetActive(true);
        }

        if (dialogueBox542.activeInHierarchy == true)
        {
            Choice541.SetActive(true);
            Choice542.SetActive(true);
        }

        if (dialogueBox551.activeInHierarchy == true)
        {
            Choice551.SetActive(true);
            Choice552.SetActive(true);
        }

        if (dialogueBox61.activeInHierarchy == true)
        {
            Choice611.SetActive(true);
            Choice612.SetActive(true);
            //StartCoroutine(ActivateOptions());
        }

        if (dialogueBox621.activeInHierarchy == true)
        {
            Choice621.SetActive(true);
            Choice622.SetActive(true);
            //StartCoroutine(ActivateOptions());
        }

        if (dialogueBox631.activeInHierarchy == true)
        {
            Choice631.SetActive(true);
            Choice632.SetActive(true);
        }

        if (dialogueBox642.activeInHierarchy == true)
        {
            Choice641.SetActive(true);
            Choice642.SetActive(true);
        }

        if (dialogueBox651.activeInHierarchy == true)
        {
            Choice651.SetActive(true);
            Choice652.SetActive(true);
        }

        if (dialogueBox71.activeInHierarchy == true)
        {
            Choice711.SetActive(true);
            Choice712.SetActive(true);
            //StartCoroutine(ActivateOptions());
        }

        if (dialogueBox721.activeInHierarchy == true)
        {
            Choice721.SetActive(true);
            Choice722.SetActive(true);
            //StartCoroutine(ActivateOptions());
        }

        if (dialogueBox731.activeInHierarchy == true)
        {
            Choice731.SetActive(true);
            Choice732.SetActive(true);
        }

        if (dialogueBox742.activeInHierarchy == true)
        {
            Choice741.SetActive(true);
            Choice742.SetActive(true);
        }

        if (dialogueBox751.activeInHierarchy == true)
        {
            Choice751.SetActive(true);
            Choice752.SetActive(true);
        }
    }

    IEnumerator ReopenDialogue()
    {
        yield return new WaitForSeconds(dialogueReopen);

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

            StartCoroutine(ActivateOptions());
        }
    }

        IEnumerator ActivateDialouge()
    {
        yield return new WaitForSeconds(7);

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

        if (dialogueBox21.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox221.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox231.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox242.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox31.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox321.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox331.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox342.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox51.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox521.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox531.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox542.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox551.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox61.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox621.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox631.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox642.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox651.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox71.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox721.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox731.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox742.activeInHierarchy == true)
        {
            StartCoroutine(ActivateOptions());
        }

        if (dialogueBox751.activeInHierarchy == true)
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

    public void ChoiceOption211()
    {


        dialogueBox21.SetActive(false);
        dialogueBox221.SetActive(true);

        Choice211.SetActive(false);
        Choice212.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption212()
    {


        dialogueBox21.SetActive(false);
        dialogueBox222.SetActive(true);

        Choice211.SetActive(false);
        Choice212.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption221()
    {
        dialogueBox221.SetActive(false);
        dialogueBox231.SetActive(true);

        Choice221.SetActive(false);
        Choice222.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption222()
    {
        dialogueBox221.SetActive(false);
        dialogueBox232.SetActive(true);

        Choice221.SetActive(false);
        Choice222.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption231()
    {
        dialogueBox231.SetActive(false);
        dialogueBox241.SetActive(true);

        Choice231.SetActive(false);
        Choice232.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption232()
    {
        dialogueBox231.SetActive(false);
        dialogueBox242.SetActive(true);

        Choice231.SetActive(false);
        Choice232.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption241()
    {
        dialogueBox242.SetActive(false);
        dialogueBox25.SetActive(true);

        Choice241.SetActive(false);
        Choice242.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption311()
    {


        dialogueBox31.SetActive(false);
        dialogueBox321.SetActive(true);

        Choice311.SetActive(false);
        Choice312.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption312()
    {


        dialogueBox31.SetActive(false);
        dialogueBox322.SetActive(true);

        Choice311.SetActive(false);
        Choice312.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption321()
    {
        dialogueBox321.SetActive(false);
        dialogueBox331.SetActive(true);

        Choice321.SetActive(false);
        Choice322.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption322()
    {
        dialogueBox321.SetActive(false);
        dialogueBox332.SetActive(true);

        Choice321.SetActive(false);
        Choice322.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption331()
    {
        dialogueBox331.SetActive(false);
        dialogueBox341.SetActive(true);

        Choice331.SetActive(false);
        Choice332.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption332()
    {
        dialogueBox331.SetActive(false);
        dialogueBox342.SetActive(true);

        Choice331.SetActive(false);
        Choice332.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption341()
    {
        dialogueBox342.SetActive(false);
        dialogueBox35.SetActive(true);

        Choice341.SetActive(false);
        Choice342.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption511()
    {


        dialogueBox51.SetActive(false);
        dialogueBox521.SetActive(true);

        Choice511.SetActive(false);
        Choice512.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption512()
    {


        dialogueBox51.SetActive(false);
        dialogueBox522.SetActive(true);

        Choice511.SetActive(false);
        Choice512.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption521()
    {
        dialogueBox521.SetActive(false);
        dialogueBox531.SetActive(true);

        Choice521.SetActive(false);
        Choice522.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption522()
    {
        dialogueBox521.SetActive(false);
        dialogueBox532.SetActive(true);

        Choice521.SetActive(false);
        Choice522.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption531()
    {
        dialogueBox531.SetActive(false);
        dialogueBox541.SetActive(true);

        Choice531.SetActive(false);
        Choice532.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption532()
    {
        dialogueBox531.SetActive(false);
        dialogueBox542.SetActive(true);

        Choice531.SetActive(false);
        Choice532.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption541()
    {
        dialogueBox542.SetActive(false);
        dialogueBox551.SetActive(true);

        Choice541.SetActive(false);
        Choice542.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption542()
    {
        dialogueBox542.SetActive(false);
        dialogueBox552.SetActive(true);

        Choice541.SetActive(false);
        Choice542.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption551()
    {
        dialogueBox551.SetActive(false);
        dialogueBox56.SetActive(true);

        Choice551.SetActive(false);
        Choice552.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption611()
    {


        dialogueBox61.SetActive(false);
        dialogueBox621.SetActive(true);

        Choice611.SetActive(false);
        Choice612.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption612()
    {


        dialogueBox61.SetActive(false);
        dialogueBox622.SetActive(true);

        Choice611.SetActive(false);
        Choice612.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption621()
    {
        dialogueBox621.SetActive(false);
        dialogueBox631.SetActive(true);

        Choice621.SetActive(false);
        Choice622.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption622()
    {
        dialogueBox621.SetActive(false);
        dialogueBox632.SetActive(true);

        Choice621.SetActive(false);
        Choice622.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption631()
    {
        dialogueBox631.SetActive(false);
        dialogueBox641.SetActive(true);

        Choice631.SetActive(false);
        Choice632.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption632()
    {
        dialogueBox631.SetActive(false);
        dialogueBox642.SetActive(true);

        Choice631.SetActive(false);
        Choice632.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption641()
    {
        dialogueBox642.SetActive(false);
        dialogueBox651.SetActive(true);

        Choice641.SetActive(false);
        Choice642.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption642()
    {
        dialogueBox642.SetActive(false);
        dialogueBox652.SetActive(true);

        Choice641.SetActive(false);
        Choice642.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption651()
    {
        dialogueBox651.SetActive(false);
        dialogueBox66.SetActive(true);

        Choice651.SetActive(false);
        Choice652.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption711()
    {


        dialogueBox71.SetActive(false);
        dialogueBox721.SetActive(true);

        Choice711.SetActive(false);
        Choice712.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption712()
    {


        dialogueBox71.SetActive(false);
        dialogueBox722.SetActive(true);

        Choice711.SetActive(false);
        Choice712.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption721()
    {
        dialogueBox721.SetActive(false);
        dialogueBox731.SetActive(true);

        Choice721.SetActive(false);
        Choice722.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption722()
    {
        dialogueBox721.SetActive(false);
        dialogueBox732.SetActive(true);

        Choice721.SetActive(false);
        Choice722.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption731()
    {
        dialogueBox731.SetActive(false);
        dialogueBox741.SetActive(true);

        Choice731.SetActive(false);
        Choice732.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption732()
    {
        dialogueBox731.SetActive(false);
        dialogueBox742.SetActive(true);

        Choice731.SetActive(false);
        Choice732.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption741()
    {
        dialogueBox742.SetActive(false);
        dialogueBox751.SetActive(true);

        Choice741.SetActive(false);
        Choice742.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption742()
    {
        dialogueBox742.SetActive(false);
        dialogueBox752.SetActive(true);

        Choice741.SetActive(false);
        Choice742.SetActive(false);

        StartCoroutine(ActivateOptions());
    }

    public void ChoiceOption751()
    {
        dialogueBox751.SetActive(false);
        dialogueBox76.SetActive(true);

        Choice751.SetActive(false);
        Choice752.SetActive(false);

        StartCoroutine(ActivateOptions());
    }
}
