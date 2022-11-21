using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterByLetter : MonoBehaviour
{
    public float delay = 0.5f;
    public string fullText;
    private string currentText = "";
    [SerializeField] private GameObject dialogue;


    void Start()
    {
        StartCoroutine(ShowText());
    }

 

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i ++) 
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }



}
