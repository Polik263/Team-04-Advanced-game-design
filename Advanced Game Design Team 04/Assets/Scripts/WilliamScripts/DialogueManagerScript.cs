using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{
    public static DialogueManagerScript Instance;

    [SerializeField] private GameObject startDialogue;

    [SerializeField] private GameObject panel;

    [SerializeField] private PlayerController _player;

    [SerializeField] private LetterByLetter _letterByLetterScript;
    [SerializeField] private OptionsLetterByLetter _optionsLetterByLetterScript;

    [SerializeField] private GameObject DialogueBox;
    [SerializeField] private TextMeshProUGUI DialogueBoxTMP;
    [SerializeField] public OptionsLetterByLetter[] choiceBoxes;

    public AudioClip dialogue1;
    public AudioClip dialogue2;

    public float dialogueDuration = 21;
    public float optionSpawn = 21;
    public float dialogueReopen = 25;

    public bool isInDialogue;

    public int currentDialogueNode = 1;

    public int selectedOption;

    private bool setEventFunction = false;


    [SerializeField] private bool isClosingDialogue;

    private void Awake()
    {
        Instance = this;

        _player = PlayerController.Instance;

        DialogueBoxTMP = DialogueBox.GetComponent<TextMeshProUGUI>();
        _letterByLetterScript = DialogueBox.GetComponent<LetterByLetter>();
    }

    public void Event1()
    {
        if (!setEventFunction)
        {
            for (int i = 0; i < 1; i++)
            {
                choiceBoxes[i].ButtonFunction.onClick.AddListener(Event1);
            }
            setEventFunction = true;
        }

        switch (currentDialogueNode)
        {
            // ENTRY POINT FOR DIALOGUE
            case 0:
                PlayDialogue("You solved the puzzle. You unleashed the power. There is no turning back - I will not rest until I get what I want. And what I want... is you.", 1, "Where did you take them?!", null, null, null);
                AudioManager.Instance.PlaySFX("Dialogue1");
                break;
            // PLAYERS FIRST CHOICE
            case 1:
                PlayDialogue("They are all with me now... But the balance is only four souls, and that, as you now know, was not our contract.", 1, "No...", null, null, null);
                AudioManager.Instance.PlaySFX("Dialogue2");
                break;
            // PLAYERS SECOND CHOICE
            case 2:
                PlayDialogue("Welcome to the worst nightmare of all.", 1, "No!", null, null, null);
                AudioManager.Instance.PlaySFX("Dialogue3");
                break;
            // PLAYERS THIRD CHOICE - PLAYER DIES
            case 3:
                PlayDialogue("Reality.", 1, "NOOO!", null, null, null);
                AudioManager.Instance.PlaySFX("Dialogue4");
                break;
            case 4:
                CloseDialogue();
                break;

        }

        currentDialogueNode++;
    }


    private void Start()
    {
        StartCoroutine(ActivateDialouge());
    }

    public void PlayDialogue(string textToBeDisplayed, int numberOfChoices, string choice1, string choice2, string choice3, string choice4)
    {
        DialogueBox.SetActive(false);

        for (int i = 0; i < choiceBoxes.Length; i++)
        {
            choiceBoxes[i].gameObject.SetActive(false);
        }

        //for (int i = 0; i < numberOfChoices; i++)
        //{
        //    choiceBoxes[i].gameObject.SetActive(true);
        //}

        DialogueBoxTMP.text = textToBeDisplayed;
        _letterByLetterScript.fullText = textToBeDisplayed;

        DialogueBox.SetActive(true);
        panel.SetActive(true);

        switch (numberOfChoices)
        {
            case 1:
                choiceBoxes[0].fullText = "1. " + choice1;
                break;
            case 2:
                choiceBoxes[0].fullText = "1. " + choice1;
                choiceBoxes[1].fullText = "2. " + choice2;
                break;
            case 3:
                choiceBoxes[0].fullText = "1. " + choice1;
                choiceBoxes[1].fullText = "2. " + choice2;
                choiceBoxes[2].fullText = "3. " + choice3;
                break;
            case 4:
                choiceBoxes[0].fullText = "1. " + choice1;
                choiceBoxes[1].fullText = "2. " + choice2;
                choiceBoxes[2].fullText = "3. " + choice3;
                choiceBoxes[3].fullText = "4. " + choice4;
                break;
        }
    }


    private void Update()
    {
        if (panel.activeInHierarchy == true)
        {
            isInDialogue = true;
        }

        Debug.Log("current node" + currentDialogueNode);

        {
            if (isClosingDialogue == false)
            {
                //StartCoroutine(CloseDialogues());
                Debug.Log("Preparing to close dialogue!");
            }

        }
    }

    void CloseDialogue()
    {
        Debug.Log("Deactivating Dialogue");

        panel.SetActive(false);

        isInDialogue = false;
        isClosingDialogue = false;
    }
    
    IEnumerator CloseDialogues()
    {
        isClosingDialogue = true;

        yield return new WaitForSeconds(dialogueDuration);
        CloseDialogue();
    }

    IEnumerator ReopenDialogue()
    {
        yield return new WaitForSeconds(dialogueReopen);

        if (panel.activeInHierarchy == false)
        {
            isInDialogue = false;
            panel.SetActive(true);

            startDialogue.SetActive(true);

        }
    }

    IEnumerator ActivateDialouge()
    {
        yield return new WaitForSeconds(7);

        if (panel.activeInHierarchy == false)
        {
            isInDialogue = false;
            panel.SetActive(true);

            startDialogue.SetActive(true);

        }

    }
}
