using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamDmg : MonoBehaviour
{
    GameObject player;
    public GameObject swordobj;
    Sword sword;
    bool canMove;
    void Start()
    {
        player = GameObject.Find("Bob");
        sword = swordobj.GetComponent<Sword>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        canMove = player.GetComponent<PlayerMovement>().canMove;
        if (canMove == false)
        {
            if (sword.currentForm == 1)
            {
                Debug.Log(collision.gameObject.layer);
                if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {

                    collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(25);
                    
                }
            }


        }

    }
}
