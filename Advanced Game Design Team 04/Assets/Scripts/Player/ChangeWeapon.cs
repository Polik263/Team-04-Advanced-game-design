using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeWeapon : MonoBehaviour
{
    private PlayerControls playerControls;
    private InputAction dialouge;


    [SerializeField] private GameObject dialougeBox;
    [SerializeField] private bool isInDialouge;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        dialouge = playerControls.Dialouge.Appear;
        dialouge.Enable();

        dialouge.performed += HandleDialouge;
    }

    private void OnDisable()
    {
        dialouge.Disable();
    }

    void HandleDialouge(InputAction.CallbackContext context) 
    {
        isInDialouge = !isInDialouge;

        if(isInDialouge)
        {
            ActivateDialouge();
        }

        else
        {
            DeactivateDialouge();
        }
    }

    public void ActivateDialouge()
    {
        dialougeBox.SetActive(true);
    }

    public void DeactivateDialouge()
    {
        dialougeBox.SetActive(false);
        isInDialouge= false;
    }
}
