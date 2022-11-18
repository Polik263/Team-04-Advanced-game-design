using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Choices : MonoBehaviour
{
    public GameObject TextBox03;
    public GameObject TextBox02;
    public GameObject TextBox;
    public GameObject Choice01;
    public GameObject Choice02;



    public void ChoiceOption1()
    {
        TextBox02.SetActive(true);
        Choice01.SetActive(false);
        Choice02.SetActive(false);
        TextBox.SetActive(false);
    }
    public void ChoiceOption2()
    {
        TextBox03.SetActive(true);
        Choice01.SetActive(false);
        Choice02.SetActive(false);
        TextBox.SetActive(false);
    }

    void Update()
    {
        
    }
}
