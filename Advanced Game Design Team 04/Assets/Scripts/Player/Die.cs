using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    XpSystem xpSystem;
    void Start()
    {
        player = GameObject.Find("Player");
        xpSystem = player.GetComponent<XpSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dead()
    {
        xpSystem.GainXp(500f);
        Destroy(gameObject);
    }
}
