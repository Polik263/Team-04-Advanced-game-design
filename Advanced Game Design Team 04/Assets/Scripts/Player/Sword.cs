using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
     public bool isCd;
    public float cd;
    public Animator animator;
    public LayerMask enemyLayers;
    public GameObject Gun;
    float saveacd;
    public bool isacd;
    public float acd;
    float savecd;
    public float currentForm = 0;
    public Material darkMaterial;
    public Material lightMaterial;
    PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
        animator = Gun.GetComponent<Animator>();
        savecd = cd;
        saveacd = acd;
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
                }
        } 
    }
    public void Attack()
    {  
        if(isCd == false)
        {
            isCd = true;
            isacd = true;
            animator.Play("Slapping");
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(isacd)
        {
            if(currentForm == 0)
            {
                if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {   
                    collision.gameObject.GetComponent<Die>().Dead();
                    playerHealth.TakeDamage(5);
                }
            }     
        }

    }
    private void OnTriggerEnter(Collider collider)
    {
        if(isacd)
        {
            if(currentForm == 1)
            {
                
                if(collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
                {
                    Destroy(collider.gameObject);
                    playerHealth.Heal(5);
                }
            }
        }

    }

    public void SwitchForm()
    {
        
        if(currentForm == 0)
        {
            Debug.Log("dark");
            Gun.GetComponent<MeshRenderer>().material = darkMaterial; 
        }
        else if(currentForm == 1)
        {
            Debug.Log("light");
            Gun.GetComponent<MeshRenderer>().material = lightMaterial; 
        }
        
    }
}
