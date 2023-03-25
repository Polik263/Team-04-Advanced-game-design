using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDebugger : MonoBehaviour
{
    public bool activated = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !activated)
        {
            DialogueManagerScript.Instance?.Event5();
            activated = true;
        }
    }
}
