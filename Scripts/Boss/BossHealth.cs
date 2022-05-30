using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int bossHealth = 20;
    public bool bossDead = false;
    private Animator anim;
    public BossController bossController;
    private CapsuleCollider capsuleCollider;
    private BoxCollider weaponCollider;
    private SphereCollider triggerCollider;
    public Material hurtBossMaterial;
    private GameObject bossModel;
    public GameObject videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Boss").GetComponent<Animator>();
        bossController = GameObject.Find("Boss").GetComponent<BossController>();
        capsuleCollider = GameObject.Find("Boss").GetComponent<CapsuleCollider>();
        weaponCollider = GameObject.Find("Boss").GetComponentInChildren<BoxCollider>();
        triggerCollider = GameObject.Find("Boss").GetComponentInChildren<SphereCollider>();
        bossModel = GameObject.FindGameObjectWithTag("BossModel");
        videoPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerWeapon" && bossHealth > 0)
        {
            bossHealth--;
            if(bossHealth < 6)
            {
                bossModel.GetComponent<Renderer>().material = hurtBossMaterial;
            }
        }
        else if(bossHealth == 0)
        {
            BossDead();
        }
    }

    void BossDead()
    {
        bossDead = true;
        anim.SetTrigger("isDead");
        bossController.bossAwake = false;
        capsuleCollider.enabled = false;
        weaponCollider.enabled = false;
        triggerCollider.enabled = false;
        StartCoroutine(playVideo());
    }

    IEnumerator playVideo()
    {
        yield return new WaitForSeconds(5);
        videoPlayer.SetActive(true);
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(0);
    }
}
