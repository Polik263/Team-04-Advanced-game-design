using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlamScript : MonoBehaviour
{

    [SerializeField] private float _slamCooldown;
    private float _lastUseTime;

    [SerializeField] private Animator animator;

    public bool isCoolingDown { get { return Time.time <= _lastUseTime + _slamCooldown; } }
    [SerializeField] public bool slamInitiated;
    [SerializeField] public bool slamEnding;

    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] public int _selfDamage;

    [SerializeField] private PlayerInput _input;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
        _input = GetComponentInParent<PlayerInput>();
    }
    private void OnEnable()
    {
        _lastUseTime = Time.time;
        _input.actions.FindAction("Slam").started += LeapSlam;
    }
    private void OnDisable()
    {
        _input.actions.FindAction("Slam").started -= LeapSlam;
    }

    public void EndLeap()
    { 
        PlayerController.Instance.canMove = true;
        slamInitiated = false;

        if (playerHealth.currentHealth <= _selfDamage)
        {
            playerHealth.currentHealth = 1;
        }
        else
        {
            playerHealth.TakeDamage(_selfDamage);
        }
    }
    public void LeapSlam(InputAction.CallbackContext context)
    {
        if(!isCoolingDown && SwordScript.Instance.CurrentSwordState == SwordScript.SwordState.Dark && !DialogueManagerScript.Instance.isInDialogue)
        {
            PlayerController.Instance.busy = true;
            PlayerController.Instance.canMove = false;

            slamInitiated = true;
            slamEnding = false;
            _lastUseTime = Time.time;

            animator.Play("LeapSlam");
            AudioManager.Instance.PlaySFX("Jump");
        }   
    }

    //This method is called by the Animator when the LeapSlam animation ends.
    public void AnimationFinished()
    {
        slamEnding = true;
        PlayerController.Instance.busy = false;
    }
    
    private void LateUpdate()
    {
        if(slamEnding && slamInitiated)
        {
            animator.transform.parent.gameObject.transform.position = animator.transform.position;
            transform.localPosition = Vector3.zero;
            animator.Play("New State");
            AudioManager.Instance.PlaySFX("Slam");
            EndLeap();
        } 
    }
}
