using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool mortal = true;
    
    public float maxHealth = 100;
    public float currentHealth;

    public HealthBar healthBar;
    //[SerializeField] private AudioSource hurt;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    void Update()
    {
        CheckPlayerHealth();
        Death();
    }

    void CheckPlayerHealth()
    {
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            //Dead
            currentHealth = 0;
        }
    }
    private void Death()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //hurt.Play();

        healthBar.SetHealth(currentHealth);

        
    }
    public void Heal(int damage)
    {
        currentHealth += damage;
            if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (mortal == true && other.CompareTag("EnemyBullet"))
        {
            TakeDamage(10);
        }

        //if (mortal == true && other.CompareTag("BossGoodBullet") || other.CompareTag("BossBadBullet"))
        //{
        //    TakeDamage(20);
        //}

    }
}
