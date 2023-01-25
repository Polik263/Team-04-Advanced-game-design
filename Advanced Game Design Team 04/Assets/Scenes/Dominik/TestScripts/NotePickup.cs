using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePickup : MonoBehaviour
{
    [SerializeField] private GameObject noteBackground;
    [SerializeField] private GameObject noteText;

    [SerializeField] private bool nextToNote;

    private void Start()
    {
        noteBackground.SetActive(false);
        noteText.SetActive(false);
        nextToNote = false;
    }

    private void Update()
    {
        if (nextToNote == true && Input.GetKeyDown(KeyCode.F)) 
        {
            Time.timeScale= 0;

            noteBackground.SetActive(true);
            noteText.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && noteBackground.activeInHierarchy == true && noteText.activeInHierarchy == true)
        {
            Time.timeScale = 1;

            noteBackground.SetActive(false);
            noteText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
            
    {
        if(other.tag == "Player")
        {
            nextToNote = true;
        }
    }

    private void OnTriggerExit(Collider other)

    {
        if (other.tag == "Player")
        {
            nextToNote = false;
        }
    }
}
