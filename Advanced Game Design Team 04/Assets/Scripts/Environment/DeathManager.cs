using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public GameObject door;

    private void Update()
    {
        GameObject[] enemy;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length == 0)
        {
            door.SetActive(true);
        }
    }
}
