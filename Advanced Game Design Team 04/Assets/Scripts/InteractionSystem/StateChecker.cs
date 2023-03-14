using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StateChecker : MonoBehaviour
{
    public bool CanRead = false;

    private void Update()
    {
        //if (Keyboard.current.qKey.wasPressedThisFrame) CanRead= !CanRead;
    }


}
