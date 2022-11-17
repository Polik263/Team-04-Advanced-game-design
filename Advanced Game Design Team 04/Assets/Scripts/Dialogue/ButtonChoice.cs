using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChoice : MonoBehaviour
{

    [SerializeField] private Button button1;

    public KeyCode key;


    void Awake()
    {
 
        button1 = GetComponent<Button>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            button1.onClick.Invoke();
        }
    }
}
