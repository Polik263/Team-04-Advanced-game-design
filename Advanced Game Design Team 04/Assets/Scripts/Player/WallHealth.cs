using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallHealth : MonoBehaviour
{
    

    public float maxHealth = 100;
    public float currentHealth;

    
    //[SerializeField] private AudioSource hurt;

  

    void Start()
    {
        currentHealth = maxHealth;
        
    }

    void Update()
    {
        
        Death();
    }

   
    private void Death()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //hurt.Play();

       


    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(0);
        }

        //if (mortal == true && other.CompareTag("BossGoodBullet") || other.CompareTag("BossBadBullet"))
        //{
        //    TakeDamage(20);
        //}

    }
}
