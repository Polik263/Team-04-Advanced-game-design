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
    PlayerHealth playerHealth;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private GameObject bullet;
    public int damage;
    public int takeDamage;

    bool darkPassive = true;
    public float longerAttack;

    GameObject dialogueManager;
    public BoxCollider boxCollider;

    bool gotReflect;
    bool gotDamage;
    bool gotDarkExtension;
    public ParticleSystem hitParticles;
    public ParticleSystem darkParticle;
    GameObject player;
    float pcd = 0.15f;
    float savepcd;
    bool ispcd;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerHealth = GetComponentInParent<PlayerHealth>();
        animator = Gun.GetComponent<Animator>();
        savecd = cd;
        saveacd = acd;
        savepcd = pcd;
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
            if (ispcd == true)
        {

            pcd -= Time.deltaTime;
            if (pcd <= 0)
            {
                ispcd = false;
                pcd = savepcd;
                Instantiate(darkParticle, player.transform.position, Quaternion.Euler(-90,0,0));
            }
        }
    }
    public void Attack()
    {

        dialogueManager = GameObject.Find("DialogueManager");
        gotDarkExtension = dialogueManager.GetComponent<DialogueMaster>().gotDarkExtension;

        if (isCd == false)
        {
            isCd = true;
            isacd = true;
            if (currentForm == 0)
            {
                if(gotDarkExtension == true)
                {
                    boxCollider.size = new Vector3(boxCollider.size.x, longerAttack, 3 );
                    boxCollider.center = new Vector3 (boxCollider.center.x, longerAttack/2, boxCollider.center.z);
                    animator.Play("Slapping");  
                    ispcd = true;
                }
                else
                {
                    animator.Play("Slapping");
                }
                

            }
            if (currentForm == 1)
            {
                animator.Play("DarkSwing");
            }
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        dialogueManager = GameObject.Find("DialogueManager");
        gotReflect = dialogueManager.GetComponent<DialogueMaster>().gotReflect;
        gotDamage = dialogueManager.GetComponent<DialogueMaster>().gotDamage;

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

                        Instantiate(hitParticles, collider.transform.position, collider.transform.rotation);
                        Instantiate(bullet, BulletSpawn, new Quaternion());
                    }
                    Destroy(collider.gameObject);
                    playerHealth.Heal(5);
                }

            }
            if(currentForm == 0 && gotDamage == true)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("EnemyHit") && isacd == true)
                {
                    
                    collider.gameObject.GetComponent<DmgEnemy>().Damage(damage);
                    playerHealth.TakeDamage(takeDamage);
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
