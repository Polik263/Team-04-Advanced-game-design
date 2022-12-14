using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 targetOffset;
    [SerializeField] private float movementSpeed;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("No target");
            target = GameObject.Find("Player").transform;
            
        }
    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, movementSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        MoveCamera();
    }
}
