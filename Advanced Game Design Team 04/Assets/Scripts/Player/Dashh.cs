using System;
using System.Collections;
using UnityEngine;

public class Dashh : MonoBehaviour
{
    PlayerMovement playermovement;
    CharacterController controller;
    Sword sword;
    public float multiplier;
    public Action<bool> isDashing;

    GameObject dialogueManager;

    bool gotLightDash;

    private void Awake()
    {
        playermovement = GetComponent<PlayerMovement>();
        controller = GetComponent<CharacterController>();
        sword = GameObject.Find("Sword").GetComponent<Sword>();
    }

    public void ApplyDash(Vector3 Direction, float speed, float duration) => StartCoroutine(Execute(Direction, speed, duration));


    IEnumerator Execute(Vector3 Direction, float speed, float duration)
    {
        dialogueManager = GameObject.Find("DialogueManager");
        gotLightDash = dialogueManager.GetComponent<DialogueMaster>().gotLightDash;

        isDashing?.Invoke(true);
        playermovement.canMove = false;
        if(sword.currentForm == 1 && gotLightDash == true)
        {
            while(duration > 0)
            {
                duration -= Time.deltaTime;

                //rb.MovePosition(transform.position + rb.velocity.normalized * speed * Time.deltaTime);
                controller.Move(new Vector3(Direction.x, 0, Direction.y) * Time.deltaTime * speed * multiplier);
                
                yield return null;

            }
        }
        else
        {
            while(duration > 0)
            {
                duration -= Time.deltaTime;

                //rb.MovePosition(transform.position + rb.velocity.normalized * speed * Time.deltaTime);
                controller.Move(new Vector3(Direction.x, 0, Direction.y) * Time.deltaTime * speed);
                
                yield return null;

            }
        }

        playermovement.canMove = true;
        isDashing?.Invoke(false);
        AudioManager.Instance.PlaySFX("Dash");

    }
}
