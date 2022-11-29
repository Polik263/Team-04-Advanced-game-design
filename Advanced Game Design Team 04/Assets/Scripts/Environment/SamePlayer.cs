using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamePlayer : MonoBehaviour
{

    void Awake()
    {
        for (int i = 0; i < Object.FindObjectsOfType<SamePlayer>().Length; i++)
        {
            if (Object.FindObjectsOfType<SamePlayer>()[i] != this)
            {

                if (Object.FindObjectsOfType<SamePlayer>()[i].name == gameObject.name)
                {
                    Destroy(gameObject);
                }
            }
        }



        DontDestroyOnLoad(gameObject);
    }


}
