using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgEnemy : MonoBehaviour
{
    public PlayerHealth playerHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        playerHealth.TakeDamage(damage);
    }
}
