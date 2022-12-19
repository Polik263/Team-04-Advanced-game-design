using System.Collections;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
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

    public int currentForm = 0;

    [Header("Logistics")]
    [SerializeField] private GameObject _dialogueManagerGO;
    [SerializeField] private GameObject _reflectedBulletGO;
    [SerializeField] private GameObject _swordGO;
    [SerializeField] private GameObject _playerGO;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private BoxCollider _weaponHitbox;
    [SerializeField] private LayerMask _enemyLayers;

    [Header("Conditions")]
    [SerializeField] private bool _coolingDown;
    [SerializeField] private bool _attackCoolingDown;
    [SerializeField] private bool _parryCoolingDown;

    [SerializeField] private bool canTakeDamage;
    [SerializeField] private bool darkPassive = true;
    [SerializeField] private bool gotReflect;
    [SerializeField] private bool gotDamage;
    [SerializeField] private bool gotDarkExtension;

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

    public void Attack()
    {
        if (_coolingDown == false)
        {
            _weaponHitbox.enabled = true;
            _coolingDown = true;
            _attackCoolingDown = true;
            _weaponHitbox.size = startHitbox;
            _weaponHitbox.center = startCenter;
            if (currentForm == 0)
            {
                _damage = _conedmg;
                _animator.Play("DarkFrontal");
            }
            if (currentForm == 1)
            {
                _animator.Play("DarkSwing");
            }
        }
    }

    public void LongerAttack()
    {
        if (_coolingDown == false)
        {
           _weaponHitbox.enabled = true;
           _coolingDown = true;
           _attackCoolingDown = true;
                    
           if (currentForm == 0)
           {
              if (gotDarkExtension == true)
              {
                  _weaponHitbox.size = ExtensionHitbox;
                  _weaponHitbox.center = ExtentionCenter;
                  _animator.Play("Slapping");
                  _parryCoolingDown = true;
                  AudioManager.Instance.PlaySFX("Dark Attack");
                  _damage = _extensionDamage;
              }
              else
              {
                  _animator.Play("Slapping");
                  _damage = _normaldmg;     
              }
           }
        }        
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (_attackCoolingDown)
        {
            if (currentForm == 1)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
                {
                    if (true && gotReflect == true)
                    {
                        var BulletSpawn = _bulletSpawnPosition;

                        _reflectedBulletGO = collider.gameObject;
                        _reflectedBulletGO.transform.position = _playerGO.transform.position + _bulletSpawnPosition;

                        Instantiate(hitParticles, collider.transform.position, collider.transform.rotation);
                        Instantiate(_reflectedBulletGO, BulletSpawn, new Quaternion());
                    }
                    Destroy(collider.gameObject);
                    _playerHealth.Heal(5);
                    AudioManager.Instance.PlaySFX("Heal");
                }
            }
            if (currentForm == 0 && gotDamage == true)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("EnemyHit") && _attackCoolingDown == true)
                {

                    collider.gameObject.GetComponent<DmgEnemy>().Damage(_damage);
                    if (_playerHealth.currentHealth <= _selfDamage)
                    {
                        _playerHealth.currentHealth = 1;
                    }
                    else if(canTakeDamage == true)
                    {
                        _playerHealth.TakeDamage(_selfDamage);
                        StartCoroutine(TakeDamange());
                    }  
                }
            }
        }
    }


    public void SwitchForm()
    {
        if (currentForm == 0)
        {
            _animator.Play("ToDark");
        }
        else if (currentForm == 1)
        {
            _animator.Play("ToLight");
            float setpos = 0.14f;
            setpos -= Time.deltaTime;

            if (setpos <= 0)
            {
                Quaternion _playerRotation = Quaternion.Euler(39.396f, 27.271f, -1.9f);
                gameObject.transform.rotation = _playerRotation;
            }
        }
    }

    IEnumerator TakeDamange()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.4f);
        canTakeDamage = true;
    }
}
