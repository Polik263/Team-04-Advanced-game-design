using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReflectBullets : MonoBehaviour
{


    GameObject player;

    public float bulletSpeed;
    private Vector3 direction;
    public int damage;

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

    private void OnTriggerEnter(Collider collider)
    {

        //Physics.IgnoreCollision(collider.GetComponent<SphereCollider>(), GetComponent<Collider>());

        Debug.Log(collider.gameObject.layer);

        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
