using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public bool isCd;
    public float cd;
    public Animator animator;
    public LayerMask enemyLayers;
    public GameObject Gun;
    float saveacd;
    public bool isacd;
    public float acd;
    float savecd;
    public float currentForm = 0;
    public Material darkMaterial;
    public Material lightMaterial;
    PlayerHealth playerHealth;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private GameObject bullet;
    public int damage;
    public int takeDamage;



    GameObject dialogueManager;

    bool gotReflect;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
        animator = Gun.GetComponent<Animator>();
        savecd = cd;
        saveacd = acd;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCd == true)
        {

            cd -= Time.deltaTime;
            if (cd <= 0)
            {
                isCd = false;
                cd = savecd;
            }

        }
        if (isacd == true)
        {

            acd -= Time.deltaTime;
            if (acd <= 0)
            {
                isacd = false;
                acd = saveacd;
            }
        }
    }
    public void Attack()
    {
        if (isCd == false)
        {
            isCd = true;
            isacd = true;
            if (currentForm == 0)
            {
                animator.Play("Slapping");
            }
            if (currentForm == 1)
            {
                animator.Play("DarkSwing");
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isacd)
        {
            if (currentForm == 0)
            {
                if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);

                    playerHealth.TakeDamage(takeDamage);
                }
            }
        }

    }
    private void OnTriggerEnter(Collider collider)
    {
        dialogueManager = GameObject.Find("DialogueManager");
        gotReflect = dialogueManager.GetComponent<DialogueMaster>().gotReflect;


        if (isacd)
        {
            if (currentForm == 1)
            {

                if (collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
                {
                    if (true && gotReflect == true)
                    {
                        var BulletSpawn = new Vector3(bulletPosition.position.x, bulletPosition.position.y,
                        bulletPosition.position.z);


                        Instantiate(bullet, BulletSpawn, new Quaternion());
                    }
                    Destroy(collider.gameObject);
                    playerHealth.Heal(5);
                }

            }
            if(currentForm == 0)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("EnemyHit"))
                {
                    Debug.Log("aa");
                    collider.gameObject.GetComponent<DmgEnemy>().Damage(damage);

                    playerHealth.TakeDamage(5);
                }
            }


        }

    }

    public void SwitchForm()
    {

        if (currentForm == 0)
        {
            Debug.Log("dark");
            animator.Play("ToDark");
            //Gun.GetComponent<MeshRenderer>().material = darkMaterial; 
        }
        else if (currentForm == 1)
        {
            Debug.Log("ToLight");
            animator.Play("ToLight");
            float setpos = 0.14f;
            setpos -= Time.deltaTime;
            if (setpos <= 0)
            {


                Quaternion bob = Quaternion.Euler(39.396f, 27.271f, -1.9f);
                gameObject.transform.rotation = bob;
            }

            //Gun.GetComponent<MeshRenderer>().material = lightMaterial; 
        }

    }
}
