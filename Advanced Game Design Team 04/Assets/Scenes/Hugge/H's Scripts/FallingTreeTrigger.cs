using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTreeTrigger : MonoBehaviour
{
    [SerializeField] private GameObject fallingTree;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            fallingTree.GetComponent<Animator>().Play("FallingTreeAnim");
 
        }
        
       
    }
}
