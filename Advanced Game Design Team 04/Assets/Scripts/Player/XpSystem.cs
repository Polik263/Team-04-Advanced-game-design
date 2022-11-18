using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpSystem : MonoBehaviour
{
    public float currentxp;
    public float maxxp = 500;
    int currentlevel;
    int levelpoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainXp(float xp)
    {
        currentxp += xp;
        
        if(currentxp >= maxxp)
        {
            levelpoint += 1;
            Levelup();
        }
    }

    public void Levelup()
    {
        if (levelpoint >= 1)
        {
            levelpoint-= 1;
            Debug.Log("LEVEL UP");
            maxxp = maxxp * 1.2f;
            currentxp = 0;
        }
    }
}
