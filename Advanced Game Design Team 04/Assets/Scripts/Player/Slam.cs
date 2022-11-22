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
    PlayerMovement bobm;
    Meele meele;


    private void Awake()
    {
        bob = GameObject.Find("Bob");
    }
    void Start()
    {
        
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

    }

    public void EndLeap()
    { 
        bobm.canMove = true;
        meele.Attack();
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
