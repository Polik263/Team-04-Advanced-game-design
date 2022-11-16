using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private EnemyStatsSo stats;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private GameObject bullet;

    private float currentFrame;

    private void Update()
    {
        SpawnBullet();
        currentFrame -= 1 * Time.deltaTime;
    }

    void SpawnBullet()
    {
        if (currentFrame <= 0)
        {
            var BulletSpawn = new Vector3(bulletPosition.position.x, bulletPosition.position.y,
                bulletPosition.position.z);
            currentFrame = stats.timeUntilNextShot;

            Instantiate(bullet);
            //Instantiate(bullet[Random.Range(0,2)], BulletSpawn, new Quaternion()); 
        }
    }
}
