using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meele : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackRange= 0.5f;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public GameObject Gun;
    public Animator animator;
    public bool isCd;
    public float cd;
    float savecd;
    public float currentForm = 0;
    public Material darkMaterial;
    public Material lightMaterial;
    void Start()
    {
        animator = Gun.GetComponent<Animator>();
        savecd = cd;
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
    public void Attack()
    {
        if(isCd == false)
        {
            isCd = true;
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
            animator.Play("Slapping");
            foreach(Collider enemy in hitEnemies)
            {
                Debug.Log("We hit");
                if(enemy.TryGetComponent<Die>(out Die die))
                {
                    enemy.GetComponent<Die>().Dead();
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void SwitchForm()
    {
        if(currentForm == 0)
        {
            Gun.GetComponent<MeshRenderer>().material = darkMaterial; 
        }
        else if(currentForm == 1)
        {
            Gun.GetComponent<MeshRenderer>().material = lightMaterial; 
        }
        
    }
}
