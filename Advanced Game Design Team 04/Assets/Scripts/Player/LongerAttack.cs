using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider boxCollider;
    public GameObject gun;
    Animator animator;
    void Start()
    {
        animator = gun.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void Attack()
    {
        Debug.Log("A");
        boxCollider.transform.localScale = new Vector3(1f, 5f, 1.5f);
        animator.Play("DarkSwing");
    }
}
