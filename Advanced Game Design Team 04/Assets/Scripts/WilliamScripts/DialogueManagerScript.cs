using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.ExceptionServices;
using TMPro;

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
    [SerializeField] private OptionsLetterByLetter[] choiceBoxes;

    public float dialogueDuration = 21;
    public float optionSpawn = 21;
    public float dialogueReopen = 25;

    public bool isInDialogue;

    [SerializeField] private bool isClosingDialogue;

    private void Awake()
    {
        Instance = this;

        _player = PlayerController.Instance;

        DialogueBoxTMP = DialogueBox.GetComponent<TextMeshProUGUI>();
        _letterByLetterScript = DialogueBox.GetComponent<LetterByLetter>();
    }


    private void Start()
    {
        StartCoroutine(ActivateDialouge());
    }

    public void PlayDialogue(string textToBeDisplayed, int numberOfChoices, string choice1, string choice2, string choice3, string choice4)
    {
        for (int i = 0; i < choiceBoxes.Length; i++)
        {
            choiceBoxes[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < numberOfChoices; i++)
        {
            choiceBoxes[i].gameObject.SetActive(true);
        }

        DialogueBoxTMP.text = textToBeDisplayed;
        _letterByLetterScript.fullText = textToBeDisplayed;

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

        {
            if (isClosingDialogue == false)
            {
                StartCoroutine(CloseDialogues());
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
