using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPrompt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private GameObject promptPanel;

    public bool IsDisplayed = false;

    private void Start()
    {
        promptPanel.SetActive(false);
    }

    public void SetUp(string promptText1)
    {
        promptText.text = promptText1;
        promptPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    { 
        promptPanel.SetActive(false);
        IsDisplayed= false;
    }


}
