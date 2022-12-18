using System.Collections;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float _cooldown;
    private float _currentCooldown;

    [SerializeField] private float _attackCooldown;
    private float _currentAttackCooldown;

    [SerializeField] private float _parryCooldown = 0.15f;
    private float _currentParryCooldown;

    [SerializeField] private float _longerAttackMultiplier;
    [SerializeField] private int _weaponExtensionDamage;
    [SerializeField] private int _damage;
    [SerializeField] private int _selfDamage;

    public int currentForm = 0;

    [Header("Logistics")]
    [SerializeField] private GameObject _dialogueManagerGO;
    [SerializeField] private GameObject _reflectedBulletGO;
    [SerializeField] private GameObject _swordGO;
    [SerializeField] private GameObject _playerGO;
    [SerializeField] private Transform _bulletPosition;
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
            if (currentForm == 0)
            {
                if (gotDarkExtension == true)
                {
                    _weaponHitbox.size = new Vector3(_weaponHitbox.size.x, _longerAttackMultiplier, 1);
                    _weaponHitbox.center = new Vector3(_weaponHitbox.center.x, _longerAttackMultiplier / 2, _weaponHitbox.center.z);
                    _animator.Play("Slapping");
                    _parryCoolingDown = true;
                }
                else
                {
                    _animator.Play("Slapping");
                    
                }
            }
            if (currentForm == 1)
            {
                _animator.Play("DarkSwing");
                
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
                        var BulletSpawn = new Vector3(_bulletPosition.position.x, _bulletPosition.position.y,
                        _bulletPosition.position.z);

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
                    if (gotDarkExtension == true)
                    {
                        AudioManager.Instance.PlaySFX("Dark Attack");
                        collider.gameObject.GetComponent<DmgEnemy>().Damage(_weaponExtensionDamage);
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
                    else
                    {
                        AudioManager.Instance.PlaySFX("Normal Swing");
                        collider.gameObject.GetComponent<DmgEnemy>().Damage(_damage);
                        if(_playerHealth.currentHealth <= _selfDamage)
                        {
                            _playerHealth.currentHealth = 1;
                        }
                        else if( canTakeDamage == true)
                        {
                            _playerHealth.TakeDamage(_selfDamage);
                            StartCoroutine(TakeDamange());
                        }
                    }
                }
            }
        }

    }


    public void SwitchForm()
    {

        if (currentForm == 0)
        {
            Debug.Log("dark");
            _animator.Play("ToDark");
        }
        else if (currentForm == 1)
        {
            Debug.Log("ToLight");
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
