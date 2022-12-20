using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [Header("Movement")]
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float controllerDeadzone = 0.1f;
    [SerializeField] private float gamepadRotateSmoothing = 1000f;
    [SerializeField] private float smoothInputSpeed = .2f;

    [SerializeField] private CharacterController controller;
    [SerializeField] private PlayerControls playerControls;
    [SerializeField] private PlayerInput playerInput;

    [Header("Weapon")]
    [SerializeField] private GameObject SwordGO;
    [SerializeField] private SwordScript sword;

    [Header("Dash")]
    [SerializeField] private DashScript _dash;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;

    [SerializeField] private float maxMortalFrames = 0.25f;
    private float currentMortalFrame;

    [SerializeField] private float dashCooldown;
    [SerializeField] private float lastTimeDashed = 0;

    [Header("Slam")]
    [SerializeField] private SlamScript slam;

    [Header("Vectors & Input")]
    [SerializeField] private Vector2 smoothInputVelocity;
    [SerializeField] private Vector2 currentInputVector;
    [SerializeField] private Vector2 movement;
    [SerializeField] private Vector2 aim;
    [SerializeField] private Vector3 playerVelocity;

    [Header("Conditions and Unlockables")]
    [SerializeField] private bool isGamepad;
    [SerializeField] private bool _canSwitch = false;

    public bool canMove = true;

    public bool gotSlam;
    public bool gotHeal;
    public bool gotReflect;
    public bool gotLightDash;
    public bool gotDamage;
    public bool gotDarkExtension;

    [Header("Stats and Attributes")]

    [SerializeField] private XpSystem xpSystem;
    [SerializeField] private PlayerHealth playerHealth;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        playerControls = new PlayerControls();

        xpSystem = GetComponent<XpSystem>();
        controller = GetComponent<CharacterController>();

        playerInput = GetComponent<PlayerInput>();

        _dash = GetComponent<DashScript>();
        slam = GetComponentInChildren<SlamScript>();

        sword = SwordScript.Instance;
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
        if (!canMove) return;
        HandleInput();
        HandleMovement();
        HandleRotation();
        HandleDash();
        MeleeAttack();
        SwitchForm();
        SlamAttack();
        LongAttack();
    }

    void HandleInput()
    {
        movement = playerControls.Controls.Movement.ReadValue<Vector2>();
        aim = playerControls.Controls.Aim.ReadValue<Vector2>();
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

    void MeleeAttack()
    {
        if (playerControls.Controls.Shotgun.ReadValue<float>() > 0 && DialogueManagerScript.Instance.isInDialogue == false)
        {
            sword.Attack();
        }    
    }

    void LongAttack()
    {
        if(playerControls.Controls.LongerAttack.ReadValue<float>() > 0)
        {
            sword.LongerAttack();
        }
    }

    void SlamAttack()
    {
        if (sword.currentForm == 0 && gotSlam == true && DialogueManagerScript.Instance.isInDialogue == false)
        {
            if (playerControls.Controls.Slam.ReadValue<float>() > 0)
            {
                if(slam.isCoolingDown == false)
                {
                    slam.slamInitiated = true;
                    slam.slamEnding = false;
                    canMove = false;
                    slam.LeapSlam();
                }
            }
        }

    }

    void SwitchForm()
    {
        if (playerControls.Controls.SwitchForm.ReadValue<float>() > 0)
        {
            if (_canSwitch)
            {
                if (sword.currentForm == 0)
                {
                    sword.currentForm = 1;
                    sword.SwitchForm();
                    _canSwitch = false;
                }

                else if (sword.currentForm == 1)
                {
                    sword.currentForm = 0;
                    sword.SwitchForm();
                    _canSwitch = false;
                }
            }
        }
        else
        {
            _canSwitch = true;
        }
    }

    void LevelUp()
    {
        if (playerControls.Controls.LevelUp.ReadValue<float>() > 0)
        {
            xpSystem.Levelup();
        }
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }

    void HandleDash()
    {
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
                _dash.ApplyDash(movement, dashSpeed, dashTime);
            }
        }
    }
}


