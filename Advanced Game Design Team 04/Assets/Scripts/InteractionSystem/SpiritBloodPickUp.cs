using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBloodPickUp : MonoBehaviour, IInteractable, ICancelable
{
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;


    public bool Interact(Interactor interactor)
    {
        // var stateChecker = interactor.GetComponent<StateChecker>();


        //if (stateChecker == null) return false;

        //if (stateChecker.CanRead)
        // {

        PlayerController.Instance.gotDash = true;

        Destroy(this.gameObject);

        return true;
        // }

        //Debug.Log("CantRead");
        // return false;
    }



    private void Start()
    {

    }

    public bool Cancel()
    {
        return true;
    }
}
