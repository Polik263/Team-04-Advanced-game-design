using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashableWall : MonoBehaviour
{
    public BoxCollider wallCollider;
    private float wallReplenishTime = 0.2f;

    public void Start()
    {
        wallCollider = gameObject.GetComponent<BoxCollider>();
    }

    public void DisableCollider()
    {
        StartCoroutine(DisableCollision());
    }

    private IEnumerator DisableCollision()
    {
        wallCollider.enabled = false;
        yield return new WaitForSeconds(wallReplenishTime);
        wallCollider.enabled = true;
    }
}
