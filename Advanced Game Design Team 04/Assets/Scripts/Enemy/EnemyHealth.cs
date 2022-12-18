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

    public GameObject FloatingTextPrefab;
    public GameObject crit;
    public GameObject gigaCrit;
    public ParticleSystem deathParticles;
    public ParticleSystem hitParticles;

    void Start()
    {
        player = PlayerController.Instance.gameObject;
        xpSystem = player.GetComponentInChildren<XpSystem>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    void Update()
    {
        CheckPlayerHealth();
        
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
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        float ch = currentHealth;
        currentHealth -= damage;
        //hurt.Play();

        healthBar.SetHealth(currentHealth);
        if(gigaCrit && ch > currentHealth + 49)
        {
            GigaCrit(damage);
            Instantiate(hitParticles, transform.position, Quaternion.identity);
            Death();
        }
        else if(crit && ch > currentHealth + 32)
        {
            Crit(damage);
            Instantiate(hitParticles, transform.position, Quaternion.identity);
            Death();
        }  
        else if(FloatingTextPrefab && ch > currentHealth)
        {
            ShowFloatingText(damage);
            //Instantiate(hitParticles, transform.position, Quaternion.identity);
            Death();
        }
        
    }

    void ShowFloatingText(int damage)
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
        go.GetComponent<TextMesh>().text = damage.ToString();
        
    }

    void Crit(int damage)
    {
        var go = Instantiate(crit, transform.position, Quaternion.identity);
        go.GetComponent<TextMesh>().text = damage.ToString();
    }

    void GigaCrit(int damage)
    {
        var go = Instantiate(gigaCrit, transform.position, Quaternion.identity);
        go.GetComponent<TextMesh>().text = damage.ToString();
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
