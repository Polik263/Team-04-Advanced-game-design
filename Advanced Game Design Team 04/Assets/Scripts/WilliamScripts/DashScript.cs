using System;
using System.Collections;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float multiplier;
    [SerializeField] public Action<bool> isDashing;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void ApplyDash(Vector3 Direction, float speed, float duration) => StartCoroutine(Execute(Direction, speed, duration));

    IEnumerator Execute(Vector3 Direction, float speed, float duration)
    {
        isDashing?.Invoke(true);
        AudioManager.Instance.PlaySFX("Dash");
        PlayerController.Instance.canMove = false;

        if (SwordScript.Instance.currentForm == 1 && PlayerController.Instance.gotLightDash == true)
        {
            multiplier = 1.75f;
        }
        else
        {
            multiplier = 1f;
        }

        while(duration > 0)
        {
            duration -= Time.deltaTime;
            controller.Move(new Vector3(Direction.x, 0, Direction.y) * Time.deltaTime * speed * multiplier);
            yield return null;
        }

        PlayerController.Instance.canMove = true;

        isDashing?.Invoke(false);
    }
}
