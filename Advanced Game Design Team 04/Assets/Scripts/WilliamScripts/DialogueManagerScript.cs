using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{
    public static DialogueManagerScript Instance;

    [SerializeField] private GameObject startDialogue;

    [SerializeField] private GameObject panel;

    [SerializeField] private DialogueBox[] dialogueBoxInfo;

    [SerializeField] private PlayerController _player;

    [SerializeField] private TextMeshProUGUI DialogueBoxTMP;

    [SerializeField] private OptionsLetterByLetter _optionsLetterByLetterScript;

    public LetterByLetter letterByLetterScript;

    public GameObject DialogueBox;
    public GameObject[] choiceBoxesButtons;
    public OptionsLetterByLetter[] choiceBoxes;

    public Color32 NarrationTextColor = new Color32(255, 255, 255, 255);

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

    private int badKarma = 0;
    private int goodKarma = 0;


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

    public void Event2()
    {
        if (!setEventFunction)
        {
            for (int i = 0; i < choiceBoxes.Length; i++)
            {
                choiceBoxes[i].ButtonFunction.onClick.AddListener(Event2);
            }

            setEventFunction = true;
        }

        switch (currentDialogueNode)
        {
            // ENTRY POINT FOR DIALOGUE
            case 0:
                PlayDialogue("My, my, your technique is genuinely terrible. Well, you’re lucky, because this sword can teach you how to swing a sword! With an addition of some dark magic… If you’re interested?", 2, "Yes, help me!", "I’ll do it on my own!", null, null);
                break;
            // PLAYERS FIRST CHOICE
            case 1:
                // WHAT OPTION DID THE PLAYER SELECT?
                switch (selectedOption)
                {
                    case 1:
                        // do something with the sword?
                        break;
                    case 2:
                        // Invoke event3
                        Invoke("Event3", 10f);
                        break;
                }

                EndOfDialogue();
                CloseDialogue();
                break;
            // FINAL CASE - DIALOGUE IS OVER
        }

        if (panel.activeInHierarchy)
        {
            currentDialogueNode++;
        }
    }

    public void Event3()
    {
        if (!setEventFunction)
        {
            for (int i = 0; i < choiceBoxes.Length; i++)
            {
                choiceBoxes[i].ButtonFunction.onClick.AddListener(Event3);
            }

            setEventFunction = true;
        }

        switch (currentDialogueNode)
        {
            // ENTRY POINT FOR DIALOGUE
            case 0:
                PlayDialogue("Are… Are you sure you don’t want my help? Not to be rude, but… You are not doing great…", 1, "Yeah, I could use a hand.", null, null, null);
                break;
            // FINAL CASE - DIALOGUE IS OVER
            case 1:
                Invoke("Event4", 5f);
                EndOfDialogue();
                CloseDialogue();
                break;
        }

        if (panel.activeInHierarchy)
        {
            currentDialogueNode++;
        }
    }

    public void Event4()
    {
        if (!setEventFunction)
        {
            for (int i = 0; i < choiceBoxes.Length; i++)
            {
                choiceBoxes[i].ButtonFunction.onClick.AddListener(Event4);
            }

            setEventFunction = true;
        }

        switch (currentDialogueNode)
        {
            // ENTRY POINT FOR DIALOGUE
            case 0:
                PlayDialogue("Oh my, you really are squishy, aren’t you? Didn’t I tell you? Dark magic is dark, and using it might be quite dangerous, you know? Don’t worry though, I have just the right medicine… What do you say for a little bit of light magic?", 2, "W…Whatever you say…", "Sure, enlighten me…", null, null);
                break;
            // FINAL CASE - DIALOGUE IS OVER
            case 1:
                PlayDialogue("No need to thank me! Now, try parrying their attacks!", 1, "...", null, null, null);
                break;
            case 2:
                EndOfDialogue();
                CloseDialogue();
                break;
        }

        if (panel.activeInHierarchy)
        {
            currentDialogueNode++;
        }
    }

    public void Event5()
    {
        if (!setEventFunction)
        {
            for (int i = 0; i < choiceBoxes.Length; i++)
            {
                choiceBoxes[i].ButtonFunction.onClick.AddListener(Event5);
            }

            setEventFunction = true;
        }

        switch (currentDialogueNode)
        {
            // ENTRY POINT FOR DIALOGUE
            case 0:
                PlayDialogue("Wow, this time we did it! Forgive my manners, I am…  um… I’m not quite sure, what was my name… Anyway, you shall refer to me as The Blade of Light and Darkness!", 2, "Wait, you’re a talking sword?!", "Thanks for saving me back there", null, null);
                break;
            // FINAL CASE - DIALOGUE IS OVER
            case 1:
                switch (selectedOption)
                {
                    case 1:
                        PlayDialogue("Not just any talking sword! I am the artifact of this tower, I am the lord of the light and darkness, and I am the only weapon able to defeat these foul creatures called spirits", 2, "What happened to the village?", "Spirits?", null, null);
                        break;
                    case 2:
                        PlayDialogue("You’re welcome!  You need not fear any further, as I’m the lord of the light and darkness, and the weapon capable of defeating these monsters called spirits.", 2, "What happened to the village?", "Spirits?", null, null);
                        break;
                }
                break;
            case 2:
                switch (selectedOption)
                {
                    case 1:
                        PlayDialogue("Oh, you mean the one right outside? I’m not sure exactly sure... However, maybe we could find some information about it inside the tower. It’s too dangerous to roam around the forest without, at least, a map anyway", 1, "[End Dialogue]", null, null, null);
                        break;
                    case 2:
                        PlayDialogue("The creatures of darkness. Their only purpose is to destroy all living matter. This forest is filled with them. Therefore, it might be wise to use this tower as a temporary shelter. Who knows? Maybe we will find something useful inside.", 1, "[End Dialogue]", null, null, null);
                        break;
                }
                break;
            case 3:
                EndOfDialogue();
                CloseDialogue();
                break;
        }

        if (panel.activeInHierarchy)
        {
            currentDialogueNode++;
        }
    }
    #endregion
}
