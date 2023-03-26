using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SwordScript : MonoBehaviour
{
    public enum SwordState
    {
        Dark = 0,
        Light = 1
    }

    public static SwordScript Instance;

    [Header("Attributes")]
    [SerializeField] private float _cooldown;
    private float _currentCooldown;

    [SerializeField] private float _attackCooldown;
    private float _currentAttackCooldown;

    [SerializeField] private float _parryCooldown = 0.15f;
    private float _currentParryCooldown;

    [SerializeField] private float _longerAttackMultiplier;
    [SerializeField] private int _extensionDamage = 34;
    [SerializeField] private int _damage;
    [SerializeField] private int _selfDamage = 5;
    [SerializeField] private int _normaldmg = 20;
    [SerializeField] private int _conedmg = 10;

    public enum SwordForm
    {
        Dark,
        Light
    }
    public SwordState CurrentSwordState = SwordState.Dark;
    
    public enum ParryingState
    {
        None,
        Windup,
        Melee,
        Ranged
    }
    public ParryingState CurrentParryingState
    {
        get { return _currentParryingState; }
        private set
        {
            if (value != _currentParryingState) { OnParryingStateChange.Invoke(value); }
            _currentParryingState = value;
        }
    }
    private ParryingState _currentParryingState;

    

    private SwordForm _swordState;

    [Header("Logistics")]
    [SerializeField] private GameObject _dialogueManagerGO;
    [SerializeField] private GameObject _reflectedBulletGO;
    [SerializeField] private GameObject _swordGO;
    [SerializeField] private GameObject _playerGO;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private BoxCollider _weaponHitbox;
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private PlayerInput _input;

    List<GameObject> targetsHit = new List<GameObject>();

    [Header("Conditions")]
    [SerializeField] private bool _coolingDown;
    [SerializeField] private bool _attackCoolingDown;
    [SerializeField] private bool _parryCoolingDown;

    [SerializeField] private bool canTakeDamage;
    [SerializeField] private bool darkPassive = true;
    [SerializeField] private bool gotReflect;
    [SerializeField] private bool gotDamage;
    [SerializeField] private bool gotDarkExtension;

    [Header("Light Mode Parrying")]
    [SerializeField] [Range(0.0f, 5.0f)] private float _parryingWindupDuration = 0.5f;
    [SerializeField] [Range(0.0f, 5.0f)] private float _meleeParryDuration = 0.5f; 
    [SerializeField] [Range(0, 20)] private int _rangedParryHealAmount = 5;
    [SerializeField] [Range(0, 20)] private int _meleeParryHealAmount = 5;
    [Range(0f, 1f)] public float _windupParrySpeedModifier = 0.7f;
    [Range(0f, 1f)] public float _meleeParrySpeedModifier = 0.4f;
    [Range(0f, 1f)] public float _rangedParrySpeedModifier = 0.1f;
    [SerializeField] private string _parryingWindupAnimation;
    [SerializeField] private string _meleeParryIdleAnimation;
    [SerializeField] private string _meleeParryHitAnimation;
    [SerializeField] private string _rangedParryIdleAnimation;
    [SerializeField] private string _rangedParryHitAnimation;
    private Coroutine _parryingRoutine;
    public UnityEvent<ParryingState> OnParryingStateChange;

    [Header("Cosmetics")]
    [SerializeField] private ParticleSystem hitParticles;
    [SerializeField] private ParticleSystem darkParticle;
    [SerializeField] private ParticleSystem _darkSwordTrail;
    private Vector3 startHitbox = new Vector3(1f,3.4f,1f);
    private Vector3 ExtensionHitbox = new Vector3(1f,6f,1f);
    private Vector3 startCenter = new Vector3(0,2,0);

    private Vector3 _bulletSpawnPosition = new Vector3(0, 0, 2.5f);

    private Vector3 ExtentionCenter = new Vector3(0,3,0);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _input = GetComponentInParent<PlayerInput>();
    }

    void Start()
    {
        _playerGO = PlayerController.Instance.gameObject;
        _swordGO = _playerGO.GetComponentInChildren<SwordScript>().gameObject;
        _playerHealth = GetComponentInParent<PlayerHealth>();
        _animator = _swordGO.GetComponent<Animator>();
        _weaponHitbox = gameObject.GetComponent<BoxCollider>();
        

        _currentCooldown = _cooldown;
        _currentAttackCooldown = _attackCooldown;
        _currentParryCooldown = _parryCooldown;
    }
    private void OnEnable()
    {
        _input.actions.FindAction("Shotgun").started += Attack;
        _input.actions.FindAction("Shotgun").canceled += ReleaseLightAttack;
        _input.actions.FindAction("LongerAttack").started += LongerAttack;
        _input.actions.FindAction("SwitchForm").started += SwitchForm;
        OnParryingStateChange.AddListener(SlowPlayerControllerOnParry);
    }
    private void OnDisable()
    {
        _input.actions.FindAction("Shotgun").started -= Attack;
        _input.actions.FindAction("Shotgun").canceled -= ReleaseLightAttack;
        _input.actions.FindAction("LongerAttack").started -= Attack;
        _input.actions.FindAction("SwitchForm").started -= SwitchForm;
        OnParryingStateChange.RemoveListener(SlowPlayerControllerOnParry);
    }

    void Update()
    {
        CooldownHandler();
    }

    public void CooldownHandler()
    {
        if (_coolingDown == true)
        {
            _cooldown -= Time.deltaTime;
            if (_cooldown <= 0)
            {
                _coolingDown = false;
                _cooldown = _currentCooldown;
                targetsHit.Clear();
            }
        }
        if (_attackCoolingDown == true)
        {
            _currentAttackCooldown -= Time.deltaTime;
            if (_currentAttackCooldown <= 0)
            {
                _attackCoolingDown = false;
                _currentAttackCooldown = _attackCooldown;
                _weaponHitbox.enabled = false;
                _darkSwordTrail.Stop();
            }
        }
        if (_parryCoolingDown == true)
        {
            _parryCooldown -= Time.deltaTime;
            if (_parryCooldown <= 0)
            {
                _parryCoolingDown = false;
                _parryCooldown = _currentParryCooldown;

                _darkSwordTrail.Play();
            }
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        DialogueManagerScript.Instance?.Event1();

        switch (CurrentSwordState)
        {
            case SwordState.Dark:
                if (_coolingDown) { return; }
                _weaponHitbox.size = startHitbox;
                _weaponHitbox.center = startCenter;
                _damage = _conedmg;
                _weaponHitbox.enabled = true;
                _coolingDown = true;
                _attackCoolingDown = true;
                _animator.Play("DarkFrontal");
                break;
            case SwordState.Light:
                if (CurrentParryingState != ParryingState.None) { return; }
                _parryingRoutine = StartCoroutine(LightModeParryRoutine());
                break;
        }
    }

    public void ReleaseLightAttack(InputAction.CallbackContext context) => ReleaseLightAttack();
    public void ReleaseLightAttack()
    {
        if (CurrentParryingState != ParryingState.None)
        {
            StopCoroutine(_parryingRoutine);
            _parryingRoutine = null;
            CurrentParryingState = ParryingState.None;
            _animator.Play("IdleLight");
        }
    }

    private IEnumerator LightModeParryRoutine()
    {
        _animator.Play(_parryingWindupAnimation);
        CurrentParryingState = ParryingState.Windup;

        yield return new WaitForSeconds(_parryingWindupDuration);

        CurrentParryingState = ParryingState.Melee;
        _animator.Play(_meleeParryIdleAnimation);

        yield return new WaitForSeconds(_meleeParryDuration);

        CurrentParryingState = ParryingState.Ranged;
        _animator.Play(_rangedParryIdleAnimation);
    }

    public void LongerAttack(InputAction.CallbackContext context)
    {
        if (CurrentSwordState == SwordState.Light || _coolingDown)
        {
            return;
        }

        _weaponHitbox.enabled = true;
        _coolingDown = true;
        _attackCoolingDown = true;

        if (gotDarkExtension)
        {
            _damage = _extensionDamage;
            _weaponHitbox.size = ExtensionHitbox;
            _weaponHitbox.center = ExtentionCenter;
            _animator.Play("Slapping");
            _parryCoolingDown = true;
            AudioManager.Instance.PlaySFX("Dark Attack");
        }
        else
        {
            _damage = _normaldmg;
            _weaponHitbox.size = startHitbox;
            _weaponHitbox.center = startCenter;
            _animator.Play("Slapping");
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        switch (CurrentSwordState)
        {
            case SwordState.Light:
                LightFormCollision(collider);
                break;
            case SwordState.Dark:
                DarkFormCollision(collider);
                break;
        }
    }

    private void LightFormCollision(Collider collider)
    {
        switch (LayerMask.LayerToName(collider.gameObject.layer))
        {
            case "Bullet":
                if (CurrentParryingState != ParryingState.Ranged) { return; }
                if (gotReflect)
                {
                    Instantiate(hitParticles, collider.transform.position, collider.transform.rotation);
                    Instantiate(_reflectedBulletGO, _bulletSpawnPosition, Quaternion.identity);
                }
                Destroy(collider.gameObject);
                _playerHealth.Heal(_rangedParryHealAmount);
                AudioManager.Instance.PlaySFX("Heal");
                _animator.Play(_rangedParryHitAnimation);
                break;
            case "EnemyHit":
                if (CurrentParryingState != ParryingState.Melee) { return; }

                _playerHealth.Heal(_meleeParryHealAmount);
                AudioManager.Instance.PlaySFX("Heal");
                _animator.Play(_meleeParryHitAnimation);

                Debug.Log("Melee parrying not implemented yet");
                //NOT SURE HOW TO IMPLEMENT THIS YET AS WE HAVENT FINALIZED HOW ENEMY MELEE ATTACKS WORK

                break;
        }
    }

    private void DarkFormCollision(Collider collider)
    {
        if (!gotDamage || !_attackCoolingDown || collider.gameObject.layer != LayerMask.NameToLayer("EnemyHit")) { return; }

        if (!targetsHit.Contains(collider.gameObject))
        {
            collider.gameObject.GetComponent<DmgEnemy>().Damage(_damage);
            targetsHit.Add(collider.gameObject);
        }

        if (_playerHealth.currentHealth <= _selfDamage)
        {
            _playerHealth.currentHealth = 1;
        }
        else if (canTakeDamage == true)
        {
            _playerHealth.TakeDamage(_selfDamage);
            StartCoroutine(TakeDamage());
        }
    }

    public void SwitchForm(InputAction.CallbackContext context)
    {
        switch(CurrentSwordState)
        {
            case SwordState.Dark:
                CurrentSwordState = SwordState.Light;
                _animator.Play("ToLight");

                float setpos = 0.14f;
                setpos -= Time.deltaTime;
                if (setpos <= 0)
                {
                    Quaternion _playerRotation = Quaternion.Euler(39.396f, 27.271f, -1.9f);
                    gameObject.transform.rotation = _playerRotation;
                }

                break;
            case SwordState.Light:
                CurrentSwordState = SwordState.Dark;
                ReleaseLightAttack();
                _animator.Play("ToDark");
                break;
        }
    }

    IEnumerator TakeDamage()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.4f);
        canTakeDamage = true;
    }

    private void SlowPlayerControllerOnParry(ParryingState newState)
    {
        if (PlayerController.Instance == null) { return; }
        switch(newState)
        {
            case ParryingState.Ranged:
                PlayerController.Instance.Slow(this, _rangedParrySpeedModifier);
                break;
            case ParryingState.Melee:
                PlayerController.Instance.Slow(this, _meleeParrySpeedModifier);
                break;
            case ParryingState.Windup:
                PlayerController.Instance.Slow(this, _windupParrySpeedModifier);
                break;
            case ParryingState.None:
                PlayerController.Instance.Slow(this);
                break;
        }
    }
}
