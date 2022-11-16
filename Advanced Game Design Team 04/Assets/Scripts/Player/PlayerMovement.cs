using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    [Header("Movement")]
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float controllerDeadzone = 0.1f;
    [SerializeField] private float gamepadRotateSmoothing = 1000f;
    [SerializeField] private float smoothInputSpeed = .2f;

    [Header("Dashing")]
    //[SerializeField] private AudioSource dashSound;
    public float dashSpeed;
    public float dashTime;
    [HideInInspector] public float currentMortalFrame;
    [SerializeField] private float maxMortalFrames = 0.25f;
    [SerializeField] float dashCooldown;
    private float lastTimeDashed = 0;

    [SerializeField] private bool isGamepad;

    private CharacterController controller;

    private Vector2 smoothInputVelocity;
    private Vector2 currentInputVector;
    private Vector2 movement;
    private Vector2 aim;
    private Vector3 playerVelocity;
    private Meele meele;

    private PlayerControls playerControls;
    private PlayerInput playerInput;
    bool work = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
        meele = GetComponent<Meele>();
    }
    private void Start()
    {

    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();
        //HandleShootInput();
        HandleDash();
        MeeleAttack();
        SwitchForm();
    }
    void HandleInput()
    {
        movement = playerControls.Controls.Movement.ReadValue<Vector2>();
        //aim = playerControls.Controls.Aim.ReadValue<Vector2>();
    }
    void HandleMovement()
    {
        {
            currentInputVector = Vector2.SmoothDamp(currentInputVector, movement, ref smoothInputVelocity, smoothInputSpeed);

            Vector3 move = new Vector3(currentInputVector.x, 0, currentInputVector.y);
            controller.Move(move * Time.deltaTime * playerSpeed);
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }

    void HandleRotation()
    {
        if (isGamepad)
        {
            if (Mathf.Abs(aim.x) > controllerDeadzone || Mathf.Abs(aim.y) > controllerDeadzone)
            {
                Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;
                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    Quaternion newrotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newrotation, gamepadRotateSmoothing * Time.deltaTime);
                }
            }
        }
        else
        {

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(ray, out rayLength))
            {
                Vector3 pointToLook = ray.GetPoint(rayLength);
                Debug.DrawLine(ray.origin, pointToLook, Color.cyan);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
        }
    }

    private void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }
    void MeeleAttack()
    {
        if(playerControls.Controls.Shotgun.ReadValue<float>()> 0)
        {
            Debug.Log("Swing");
            meele.Attack();
        }
    }

    void SwitchForm()
    {
        if (playerControls.Controls.SwitchForm.ReadValue <float>()>0)
        {
            if(work)
            {
                if (meele.currentForm == 0)
                {
                    meele.currentForm = 1;
                    meele.SwitchForm();
                    work = false;
                }

                else if (meele.currentForm == 1)
                {
                    meele.currentForm = 0;
                    meele.SwitchForm();
                    work = false;
                }
            }
        }
        else
        {
            work = true;
        }
    }

    //public void OnDeviceChange (PlayerInput pi)
    //{
    //    isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    //}

    //void HandleShootInput()
    //{
    //    if (Input.GetButton("Fire1"))
    //    {
    //        PlayerGun.Instance.Shoot();
    //    }
    //}

    //void HandleShotgunInput()
    //{
    //        Shotgun.Instance.ShotgunShoot();
    //}

    void HandleDash()
    {
        //timers
        currentMortalFrame -= 1 * Time.deltaTime;

        if (currentMortalFrame <= 0)
        {
            currentMortalFrame = 0;
            playerHealth.mortal = true;
        }

        playerControls.Controls.Dash.performed += ctx => Dash();

        void Dash()
        {
            if (lastTimeDashed + dashCooldown < Time.time)
            {
                lastTimeDashed = Time.time;
                StartCoroutine(DashMove());
            }
        }

        IEnumerator DashMove()
        {
            //dashSound.Play();
            currentMortalFrame = maxMortalFrames;
            playerHealth.mortal = false;

            float startTime = Time.time;

            while (Time.time < startTime + dashTime)
            {
                transform.Translate(Vector3.forward * dashSpeed);

                yield return null;
            }
        }
    }
}
    

