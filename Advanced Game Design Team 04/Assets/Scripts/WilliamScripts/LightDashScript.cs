using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDashScript : MonoBehaviour
{

    enum DashTier
    {
        tierOne,
        tierTwo,
        tierThree
    }

    [SerializeField] GameObject player;
    public GameObject swordobj;
    [SerializeField] SwordScript _sword;
    private bool _canMove;
    public int dmg;

    [SerializeField] private DashScript _dashScript;
    [SerializeField] private Collider _collider;
    
    GameObject dialogueManager;

    public bool gotLightDash;
    bool isInDialogue;

    void Start()
    {
        _sword = swordobj.GetComponent<SwordScript>();
    }

    private void OnEnable()
    {
        _dashScript.isDashing += DisableCollider;
    }
    private void OnDisable()
    {
        _dashScript.isDashing -= DisableCollider;
    }

    //This makes sure collisions work even if you're touching the colliding object when starting the dash.
    private void DisableCollider(bool dashState)
    {
        _collider.enabled = dashState;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _canMove = player.GetComponent<PlayerController>().canMove;
        
        if (_canMove == false)
        {
            if(gotLightDash == true && isInDialogue == false)
            {
                if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                
                }

                else if (collision.rigidbody != null && collision.rigidbody.CompareTag("Breakable Wall"))
                {
                    collision.gameObject.GetComponent<DashableWall>().DisableCollider();
                }
            }
        }

    }
}
