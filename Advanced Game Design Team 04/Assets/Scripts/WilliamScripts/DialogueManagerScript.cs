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

    [SerializeField] private TextMeshProUGUI DialogueBoxTMP;

    [SerializeField] private OptionsLetterByLetter _optionsLetterByLetterScript;

    public LetterByLetter letterByLetterScript;

    public GameObject DialogueBox;
    public GameObject[] choiceBoxesButtons;
    public OptionsLetterByLetter[] choiceBoxes;

    public AudioClip dialogue1;
    public AudioClip dialogue2;

    public float dialogueDuration = 21;
    public float optionSpawn = 21;
    public float dialogueReopen = 25;

    public bool isInDialogue;
    private bool setEventFunction = false;

    public int currentDialogueNode = 1;
    public int selectedOption;
    public int choicesToBeDisplayed;


    [SerializeField] private bool isClosingDialogue;

    private void Awake()
    {
        Instance = this;

        _player = PlayerController.Instance;

        DialogueBoxTMP = DialogueBox.GetComponent<TextMeshProUGUI>();
        letterByLetterScript = DialogueBox.GetComponent<LetterByLetter>();
    }

    public void PlayDialogue(string textToBeDisplayed, int numberOfChoices, string choice1, string choice2, string choice3, string choice4)
    {
        AudioManager.Instance.sfxSource.Stop();
        panel.SetActive(true);

        choicesToBeDisplayed = numberOfChoices;

        DialogueBox.SetActive(false);

        for (int i = 0; i < choiceBoxes.Length; i++)
        {
            choiceBoxes[i].gameObject.SetActive(false);
            choiceBoxesButtons[i].SetActive(false);
        }

        for (int i = 0; i < numberOfChoices; i++)
        {
            choiceBoxesButtons[i].SetActive(true);
        }

        DialogueBoxTMP.text = textToBeDisplayed;
        letterByLetterScript.fullText = textToBeDisplayed;

        DialogueBox.SetActive(true);

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
    }

    public void EndOfDialogue()
    {
        for (int i = 0; i < choiceBoxes.Length; i++)
        {
            choiceBoxes[i].ButtonFunction.onClick.RemoveAllListeners();
        }
    }

    void CloseDialogue()
    {
        AudioManager.Instance.sfxSource.Stop();

        currentDialogueNode = 0;
        panel.SetActive(false);
        DialogueBox.SetActive(false);

        isInDialogue = false;
        isClosingDialogue = false;

        if (setEventFunction)
        {
            for (int i = 0; i < 1; i++)
            {
                choiceBoxes[i].ButtonFunction.onClick.RemoveAllListeners();
                setEventFunction = false;
            }
        }
    }

    #region Events
    public void Event1()
    {
        if (!setEventFunction)
        {
           for (int i = 0; i < choiceBoxes.Length; i++)
           {
               choiceBoxes[i].ButtonFunction.onClick.AddListener(Event1);
           }

           setEventFunction = true;
        }

        switch (currentDialogueNode)
        {
            // ENTRY POINT FOR DIALOGUE
            case 0:
                PlayDialogue("You solved the puzzle. You unleashed the power. There is no turning back - I will not rest until I get what I want. And what I want... is you.", 2, "Where did you take them?!", "I summoned you.", null, null);
                break;
            // PLAYERS FIRST CHOICE
            case 1:
                // WHAT OPTION DID THE PLAYER SELECT?
                switch (selectedOption)
                {
                    case 1:
                        PlayDialogue("They are all with me now... But the balance is only four souls, and that, as you now know, was not our contract.", 1, "No...", null, null, null);
                        break;
                    case 2:
                        PlayDialogue("You summoned me - I came.", 1, "This is not what I imagined.", null, null, null);
                        choiceBoxes[1].ButtonFunction.onClick.AddListener(Event1);
                        currentDialogueNode = 4;
                        break;
                }
                break;
            // PLAYERS SECOND CHOICE
            case 2:
                PlayDialogue("Welcome to the worst nightmare of all.", 1, "No!", null, null, null);
                break;
            // PLAYERS THIRD CHOICE
            case 3:
                PlayDialogue("Reality.", 1, "NOOO!", null, null, null);
                break;
            // FINAL CASE - DIALOGUE IS OVER
            case 4:
                EndOfDialogue();
                CloseDialogue();
                break;

            // ROUTE #2
            case 5:
                PlayDialogue("This is my body. This is my blood. Happy are they who come to my supper.", 1, "[End Dialogue]", null, null, null);
                choiceBoxes[1].ButtonFunction.onClick.AddListener(Event1);
                currentDialogueNode = 3;
                break;
        }

        if (panel.activeInHierarchy)
        {
            currentDialogueNode++;
        }
    }

    #endregion
}
