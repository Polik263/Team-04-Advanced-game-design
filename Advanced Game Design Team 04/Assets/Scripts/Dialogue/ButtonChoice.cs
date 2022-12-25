using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChoice : MonoBehaviour
{

    [SerializeField] private Button button1;
    [SerializeField] private int choiceNumber;

    public KeyCode key1; 
    public KeyCode key2;


    void Awake()
    {
        
        button1 = GetComponent<Button>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(key1) && DialogueManagerScript.Instance.letterByLetterScript._dialogueFinished || Input.GetKeyDown(key2) && DialogueManagerScript.Instance.letterByLetterScript._dialogueFinished)
        {
            DialogueManagerScript.Instance.selectedOption = choiceNumber;
            button1.onClick.Invoke();
        }
    }
}
