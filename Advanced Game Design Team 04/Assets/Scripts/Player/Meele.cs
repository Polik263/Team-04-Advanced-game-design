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
    public int damage;
   
    void Start()
    {
        animator = Gun.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
 
        
    }
    public void Attack()
    {
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
            foreach(Collider enemy in hitEnemies)
            {
                Debug.Log("We hit");
                if(enemy.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
                {
                    enemy.GetComponent<PlayerHealth>().TakeDamage(damage);
                }
            }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
