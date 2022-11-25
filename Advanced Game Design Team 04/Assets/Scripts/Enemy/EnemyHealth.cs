using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public bool mortal = true;
    
    public float maxHealth = 100;
    public float currentHealth;
    GameObject player;
    XpSystem xpSystem;
    public HealthBar healthBar;
    //[SerializeField] private AudioSource hurt;

    GameObject dialogueManager;

    bool gotHeal;

    void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Start()
    {
        xpSystem = player.GetComponent<XpSystem>();
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
            xpSystem.GainXp(250);
            Destroy(gameObject);
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
        dialogueManager = GameObject.Find("DialogueManager");
        gotHeal = dialogueManager.GetComponent<DialogueMaster>().gotHeal;

        if (gotHeal == true)
        {
            currentHealth += damage;
        }
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
            TakeDamage(0);
        }

        //if (mortal == true && other.CompareTag("BossGoodBullet") || other.CompareTag("BossBadBullet"))
        //{
        //    TakeDamage(20);
        //}

    }
}
