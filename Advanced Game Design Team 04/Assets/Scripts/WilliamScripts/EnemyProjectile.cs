using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using Player;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private GameObject _playerGO;
    public GameObject destroyableWall;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private ProjectileStats stats;
    private Transform playerTransform;
    private Vector3 playerPos;
    WallHealth wallHealth;
    public int dmg;
    private Vector3 direction;

    private void Awake()
    {
        _playerGO = PlayerController.Instance.gameObject;
    }

    private void Start()
    {
        playerHealth = _playerGO.GetComponentInChildren<PlayerHealth>();
        playerTransform = _playerGO.GetComponentInChildren<Transform>();

        playerPos = playerTransform.position;
        direction = (playerPos - transform.position).normalized;
    }

    private void Update()
    {
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
