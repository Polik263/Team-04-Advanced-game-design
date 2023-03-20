using System;
using System.Collections;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private GameObject _playerGO;

    [SerializeField] private Collider _playerCollider;

    [SerializeField] private float multiplier;
    [SerializeField] public Action<bool> isDashing;
    private bool _canMove;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _playerGO = PlayerController.Instance.gameObject;
    }

    public void ApplyDash(Vector3 Direction, float speed, float duration) => StartCoroutine(Execute(Direction, speed, duration));

    IEnumerator Execute(Vector3 Direction, float speed, float duration)
    {
        if (PlayerController.Instance.gotDash == true)
        {
            isDashing?.Invoke(true);
            AudioManager.Instance.PlaySFX("Dash");
            PlayerController.Instance.canMove = false;
        }
      

        if (SwordScript.Instance.CurrentSwordState == SwordScript.SwordState.Light && PlayerController.Instance.gotLightDash == true)
        {
            multiplier = 1.75f;
        }
        else
        {
            multiplier = 1f;
        }

        while(duration > 0 && PlayerController.Instance.gotDash == true)
        {
            duration -= Time.deltaTime;
            controller.Move(new Vector3(Direction.x, 0, Direction.y) * Time.deltaTime * speed * multiplier);
            yield return null;
        }

        PlayerController.Instance.canMove = true;

        isDashing?.Invoke(false);
    }

    private void OnEnable()
    {
        isDashing += DisableCollider;
    }
    private void OnDisable()
    {
        isDashing -= DisableCollider;
    }

    //This makes sure collisions work even if you're touching the colliding object when starting the dash.
    private void DisableCollider(bool dashState)
    {
        _playerCollider.enabled = dashState;
    }
}
