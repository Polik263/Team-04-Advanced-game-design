using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    // Start is called before the first frame updat
    public float DestroyTime = 3f;

    public Vector3 Offset = new Vector3 (0, 2, 0);
    public Vector3 Randomize = new Vector3(0.5f, 0.1f, 0f);
    void Start()
    {
        Destroy(gameObject, DestroyTime);

        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(-Randomize.x, Randomize.x),
        Random.Range(-Randomize.y, Randomize.y),
        Random.Range(-Randomize.z, Randomize.z));
    }
}
