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

    private PlayerControls playerControls;
    float currentTime;


    private void OnEnable()
    {      
           StartCoroutine(ShowText()); 
    }




    IEnumerator ShowText()
    {


        for (int i = 0; i < (fullText.Length + 1); i ++) 
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        
    }



}
