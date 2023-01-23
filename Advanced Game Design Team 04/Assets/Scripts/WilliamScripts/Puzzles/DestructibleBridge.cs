using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBridge : MonoBehaviour
{
    private BoxCollider _bridgeCollider;
    private MeshRenderer _bridgeMesh;
    private Rigidbody _rigidbody;

    private GameObject _explosion;

    private int _timeUntilDestroy = 3;
    private int _respawnTimer = 10;

    private bool eventTriggered = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _bridgeCollider = GetComponent<BoxCollider>();
        _bridgeMesh = GetComponent<MeshRenderer>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !eventTriggered)
        {
            Debug.Log("Triggered");
            StartCoroutine(DestroyBridgeEvent());
            eventTriggered = true;
        }
    }

    private IEnumerator DestroyBridgeEvent()
    {
        yield return new WaitForSeconds(_timeUntilDestroy);

        var startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        _rigidbody.isKinematic = false;
        _bridgeMesh.enabled = false;
        _bridgeCollider.enabled = false;

        yield return new WaitForSeconds(_respawnTimer);

        transform.position = startPosition;

        _rigidbody.isKinematic = true;
        _bridgeMesh.enabled = true;
        _bridgeCollider.enabled = true;
    }
}
