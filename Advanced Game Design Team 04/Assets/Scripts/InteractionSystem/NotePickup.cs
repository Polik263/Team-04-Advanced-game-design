using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePickup : MonoBehaviour, IInteractable, ICancelable
{
    [SerializeField] private GameObject noteBackground;
    [SerializeField] private GameObject noteText;



    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt; 
    
    
    public bool Interact(Interactor interactor)
    {
       // var stateChecker = interactor.GetComponent<StateChecker>();


        //if (stateChecker == null) return false;

        //if (stateChecker.CanRead)
       // {
            Time.timeScale = 0;

            noteBackground.SetActive(true);
            noteText.SetActive(true);
            return true;
       // }

        //Debug.Log("CantRead");
       // return false;
    }

    

    private void Start()
    {
        noteBackground.SetActive(false);
        noteText.SetActive(false);

    }

    public bool Cancel()
    {
        Time.timeScale = 1;

        noteBackground.SetActive(false);
        noteText.SetActive(false);
        return true;
    }
}
