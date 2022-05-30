using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public bool bossAwake = false;
    private Animator anim;
    public bool inBattle = false;
    public bool attacking = false;
    public float idleTimer = 0.0f;
    public float idleWaitTime = 10.0f;
    private BossHealth bossHealth;
    public float attackTimer = 0.0f;
    public float attackWaitTime = 4.0f;
    private BoxCollider swordTrigger;
    public GameObject bossHealthBar;
    private SmoothFollow smoothFollow;
    private GameObject player;
    private PlayerHealth playerHealth;
    private BoxCollider bossCheckPoint;
    private SphereCollider headTrigger;
    private new ParticleSystem particleSystem;
    public bool moduleEnable;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bossHealth = GetComponentInChildren<BossHealth>();
        swordTrigger = GameObject.Find("Boss").GetComponentInChildren<BoxCollider>();
        headTrigger = GameObject.Find("Boss").GetComponentInChildren<SphereCollider>();
        bossHealthBar.SetActive(false);
        smoothFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SmoothFollow>();
        player = GameManager.instance.Player;
        playerHealth = player.GetComponent<PlayerHealth>();
        bossCheckPoint = GameObject.Find("BossCheckPoint").GetComponent<BoxCollider>();
        particleSystem = GameObject.Find("RockPS").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossAwake)
        {
            bossHealthBar.SetActive(true);
            headTrigger.enabled = true;
            anim.SetBool("bossAwake", true);
            if (inBattle)
            {
                if (!attacking)
                {
                    idleTimer += Time.deltaTime;
                }
                else
                {
                    idleTimer = 0.0f;
                    if(bossHealth.bossHealth >0 && playerHealth.CurrentHealth > 0)
                    {
                        if(bossHealth.bossHealth > 15)
                        {
                            attackWaitTime = 4.0f;
                        }
                        if(bossHealth.bossHealth >10 && bossHealth.bossHealth < 16)
                        {
                            attackWaitTime = 3.0f;
                        }
                        if(bossHealth.bossHealth >5 && bossHealth.bossHealth < 11)
                        {
                            attackWaitTime = 2.0f;
                        }
                        if(bossHealth.bossHealth >=1 && bossHealth.bossHealth < 6)
                        {
                            attackWaitTime = 1.0f;
                        }
                    }
                    attackTimer += Time.deltaTime;
                    if (attackTimer >= attackWaitTime)
                    {
                        switch (Random.Range(0, 3))
                        {
                            case 0: BossAttack();
                                break;
                            case 1: BossAttack02();
                                break;
                            case 2: BossAttack03();
                                break;
                            default: break;
                        }
                    }
                }
                if (idleTimer >= idleWaitTime)
                {
                    attacking = true;
                    idleTimer = 0.0f;
                }
            }
        }
        else
        {
            headTrigger.enabled = false;
        }
        BossReset();
    }
    
    void BossReset()
    {
        if(playerHealth.CurrentHealth == 0)
        {
            bossAwake = false;
            smoothFollow.bossCameraActive = false;
            bossCheckPoint.isTrigger = true;
            anim.Play("Idle");
            anim.SetBool("bossAwake", false);
            bossHealth.bossHealth = 20;
        }
    }

    void BossAttack()
    {
        attacking = false;
        anim.SetTrigger("bossAttack");
        attackTimer = 0.0f;
        swordTrigger.enabled = true;
    }

    void BossAttack02()
    {
        attacking = false;
        anim.SetTrigger("bossAttack02");
        attackTimer = 0.0f;
        swordTrigger.enabled = true;
    }

    void BossAttack03()
    {
        attacking = false;
        anim.SetTrigger("bossAttack03");
        attackTimer = 0.0f;
        swordTrigger.enabled = false;
        StartCoroutine(fallingRocks());
    }

    IEnumerator fallingRocks()
    {
        yield return new WaitForSeconds(2);
        var emission = particleSystem.emission;
        emission.enabled = !moduleEnable;
        particleSystem.Play();
        yield return new WaitForSeconds(3);
        emission.enabled = moduleEnable;
    }
}
