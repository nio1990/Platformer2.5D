using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy01Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 20;
    [SerializeField] private float timeSinceLastHit = 0.5f;
    [SerializeField] private float dissapearSpeed = 2f;
    [SerializeField] private int currentHealth;
    private float timer = 0f;
    private Animator anim;
    private NavMeshAgent nav;
    public bool isAlive;
    private new Rigidbody rigidbody;
    private CapsuleCollider capsuleCollider;
    private bool dissapearEnemy = false;

    private BoxCollider weaponCollider;
    private CapsuleCollider enemyCollider;

    private AudioSource audio;
    public AudioClip hurtAudio;
    public AudioClip deathAudio;

    private DropItems dropItem;

    /*public bool isAlive
        {
            get
            {
                return isAlive;
            }
        }*/
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        isAlive = true;
        currentHealth = startingHealth;
        weaponCollider = GetComponentInChildren<BoxCollider>();
        enemyCollider = GetComponent<CapsuleCollider>();
        audio = GetComponent<AudioSource>();

        dropItem = GetComponent<DropItems>();
    }

    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (dissapearEnemy)
        {
            transform.Translate(-Vector3.up * dissapearSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if(other.tag == "PlayerWeapon")
            {
                takeHit();
                timer = 0f;
            }
        }
    }

    void takeHit()
    {
        if(currentHealth > 0)
        {
            anim.Play("Hurt");
            currentHealth -= 10;
            audio.PlayOneShot(hurtAudio);
        }
        if (currentHealth <= 0)
        {
            isAlive = false;
            KillEnemy();
            audio.PlayOneShot(deathAudio);
        }
    }

    void KillEnemy()
    {
        capsuleCollider.enabled = false;
        nav.enabled = false;
        anim.SetTrigger("EnemyDie");
        rigidbody.isKinematic = true;
        StartCoroutine(removeEnemy());
        weaponCollider.enabled = false;
        enemyCollider.enabled = false;

        dropItem.Drop();
    }

    IEnumerator removeEnemy()
    {
        yield return new WaitForSeconds(2f);
        dissapearEnemy = true;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
