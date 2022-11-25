using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgEnemy : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        enemyHealth.TakeDamage(damage);
    }
}
