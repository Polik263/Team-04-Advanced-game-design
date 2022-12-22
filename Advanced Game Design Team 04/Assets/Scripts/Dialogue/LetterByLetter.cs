using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterByLetter : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    public string currentText = "";

    private bool _dialogueFinished;

    private PlayerControls playerControls;
    TextMeshProUGUI TMP;
    float currentTime;

    private void Awake()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        _dialogueFinished = false;

        for (int i = 0; i < (fullText.Length + 1); i ++) 
        {
            currentText = fullText.Substring(0, i);
            TMP.text = currentText;
            yield return new WaitForSeconds(delay);

            if (i == fullText.Length)
            {
                _dialogueFinished = true;

                for (int j = 0; j < 1; j++)
                {
                    DialogueManagerScript.Instance.choiceBoxes[j].gameObject.SetActive(true);
                }
            }
        }
    }
}
