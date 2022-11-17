using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Choices : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject Choice01;
    public GameObject Choice02;
    public int ChoiceMade;

    public void ChoiceOption1()
    {
        //TextBox.GetComponent<TextMeshProUGUI>().TextMeshProUGUI "gweg";
        ChoiceMade = 1;
    }

    void Update()
    {
        
    }
}
