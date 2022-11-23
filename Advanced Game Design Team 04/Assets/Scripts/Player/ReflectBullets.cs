using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReflectBullets : MonoBehaviour
{
    
    
    GameObject player;
    
    public float bulletSpeed;
    private Vector3 direction;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void Start()
    {
        direction = player.transform.forward;
    }

    private void Update()
    {
        //var step =  stats.bulletSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, playerPos, step);

        transform.position += direction * bulletSpeed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}
