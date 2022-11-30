using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private GameObject player;
    public GameObject destroyableWall;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private EnemyStatsSo stats;
    private Transform playerTransform;
    private Vector3 playerPos;
    WallHealth wallHealth;
    public int dmg;
    private Vector3 direction;


    private void Awake()
    {
        
    }


    private void Start()
    {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        playerPos = playerTransform.position;
        direction = (playerPos - transform.position).normalized;



    }

    private void Update()
    {
        //var step =  stats.bulletSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, playerPos, step);

        transform.position += direction * stats.bulletSpeed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerHealth.mortal && other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(dmg);
            Destroy(gameObject);

        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Destroyable Wall"))
        {
            other.GetComponent<WallHealth>().TakeDamage(5);

            Destroy(gameObject);
        }


    }


}
