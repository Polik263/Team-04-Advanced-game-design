using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDashScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject swordobj;
    [SerializeField] SwordScript _sword;
    bool canMove;
    public int dmg;
    
    GameObject dialogueManager;

    bool gotLightDash;
    bool isInDialogue;

    void Start()
    {
        _sword = swordobj.GetComponent<SwordScript>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        canMove = player.GetComponent<PlayerController>().canMove;

        if (canMove == false)
        {
            if(_sword.currentForm == 1 && gotLightDash == true && isInDialogue == false)
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
