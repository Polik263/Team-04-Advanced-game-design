using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    private void Start()
    {
        if(cam == null)
        {
            Debug.LogWarning("No camera");
            cam = Camera.main.transform;
        }
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);   
    }
    
}
