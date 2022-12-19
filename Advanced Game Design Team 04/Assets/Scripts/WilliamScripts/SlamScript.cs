using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamScript : MonoBehaviour
{

    [SerializeField] private float _slamCooldown;
    private float _currentCooldown;

    [SerializeField] private Animator animator;

    [SerializeField] public bool isCoolingDown = false;
    [SerializeField] public bool slamInitiated;
    [SerializeField] public bool slamEnding;

    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] public int _selfDamage;
    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        _currentCooldown = _slamCooldown;
    }

    void Update()
    {
        if(isCoolingDown == true)
        {
            _currentCooldown -= Time.deltaTime;
            if(_currentCooldown <= 0)
            {
               isCoolingDown = false;
               _currentCooldown = _slamCooldown;
            }
        }
    }

    public void EndLeap()
    { 
        PlayerController.Instance.canMove = true;

        if(playerHealth.currentHealth <= _selfDamage)
        {
            playerHealth.currentHealth = 1;
        }
        else
        {
            playerHealth.TakeDamage(_selfDamage);
        }
    }
    public void LeapSlam()
    {
        if(isCoolingDown == false)
        {
            isCoolingDown = true;
            animator.Play("LeapSlam");
            AudioManager.Instance.PlaySFX("Jump");
        }   
    }

    public void AnimationFinished()
    {
        slamEnding = true;
    }
    
    private void LateUpdate()
    {
        if(slamEnding && slamInitiated)
        {
            slamInitiated = false;

            animator.transform.parent.gameObject.transform.position = animator.transform.position;
            transform.localPosition = Vector3.zero;
            animator.Play("New State");
            AudioManager.Instance.PlaySFX("Slam");
            EndLeap();
            
        } 
    }
}
