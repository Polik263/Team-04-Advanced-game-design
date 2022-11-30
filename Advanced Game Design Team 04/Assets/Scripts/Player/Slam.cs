using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam : MonoBehaviour
{
    // Start is called before the first frame update
    public float cd;
    public bool isCd = false;
    float savecd;
    Animator animator;
    GameObject bob;
    public bool startedd;
    public bool finishedd;
    bool isacd;
    public float acd;
    float saveacd;
    PlayerMovement bobm;
    Meele meele;
    PlayerHealth playerHealth;

    public int takeDamage;
    private void Awake()
    {
        bob = GameObject.Find("Bob");
    }
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        saveacd = acd;
        bobm = GameObject.Find("Bob").GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        savecd = cd;
        meele = GetComponent<Meele>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCd == true)
        {
            cd -= Time.deltaTime;
            if(cd <= 0)
                {
                    isCd = false;
                    cd = savecd;
                }
        }
        if(isacd == true)   
        {

            acd -= Time.deltaTime;
            if (acd <= 0)
                {
                    isacd = false;
                    acd = saveacd;
                    meele.Attack();
                }
        }   

    }

    public void EndLeap()
    { 
        bobm.canMove = true;
        isacd = true;
        if(playerHealth.currentHealth <= takeDamage)
        {
            playerHealth.currentHealth = 1;
        }
        else
        {
            playerHealth.TakeDamage(takeDamage);
        }
        
  
    }
    public void LeapSlam()
    {
        if(isCd == false)
        {
            isCd = true;
            animator.Play("LeapSlam");
        }   
    }

    public void AnimationFinished()
    {
        finishedd = true;
    }
    
    private void LateUpdate()
    {

        if(finishedd && startedd)
        {
            
            startedd = false;

            animator.transform.parent.gameObject.transform.position = animator.transform.position;
            transform.localPosition = Vector3.zero;
            animator.Play("New State");
            EndLeap();
            
        } 
    }
}
