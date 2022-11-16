using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private Queue<string> sentences;

    void Start()
    {
        sentences= new Queue<string>();
    }
}
