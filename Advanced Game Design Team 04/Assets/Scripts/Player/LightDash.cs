using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDash : MonoBehaviour
{
    GameObject player;
    public GameObject swordobj;
    Sword sword;
    bool canMove;
    public int dmg;
    
    GameObject dialogueManager;

    bool gotLightDash;
    bool isInDialogue;

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
        dialogueManager = GameObject.Find("DialogueManager");
        gotLightDash = dialogueManager.GetComponent<DialogueMaster>().gotLightDash;
        isInDialogue = dialogueManager.GetComponent<DialogueMaster>().isInDialogue;

        canMove = player.GetComponent<PlayerMovement>().canMove;
        if (canMove == false)
        {
            if(sword.currentForm == 1 && gotLightDash == true && isInDialogue == false)
            {
                //Debug.Log(collision.gameObject.layer);
                if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                
                    //collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(dmg);
                }

                else if (collision.rigidbody.CompareTag("Breakable Wall"))
                {
                    Debug.Log("Dash!");
                    Destroy(collision.gameObject);
                }
            }

           
            

        }

    }
}
