using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private EnemyStatsSo stats;
    private Transform playerTransform;
    private Vector3 playerPos;

    private Vector3 direction;

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
            playerHealth.TakeDamage(5);
            Destroy(gameObject);

        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        
    }


}
