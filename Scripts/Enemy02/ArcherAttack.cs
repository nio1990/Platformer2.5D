using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : MonoBehaviour
{
    [SerializeField] private float range = 30f;
    [SerializeField] private float timeBetweenAttacks = 5f;
    private Animator anim;
    public GameObject player;
    private bool playerInRange;
    public float arrowSpeed = 600f;
    public Transform arrowSpawn;
    public Rigidbody arrowPrefab;
    Rigidbody clone;

    // Start is called before the first frame update
    void Start()
    {
        arrowSpawn = GameObject.Find("ArrowSpawn").transform;
        anim = GetComponent<Animator>();
        player = GameManager.instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < range)
        {
            playerInRange = true;
            anim.SetTrigger("isAttacking");
        }
        else
        {
            playerInRange = false;
        }
    }

    public void FireArcherProjectile()
    {
        clone = Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation) as Rigidbody;
        clone.AddForce(-arrowSpawn.transform.right * arrowSpeed);
    }
}
