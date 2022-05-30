using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 10;
    [SerializeField] private int currentHealth;
    private new Rigidbody rigidbody;
    private SphereCollider sphereCollider;
    public GameObject explosionEffect;
    private bool dissapearEnemy = false;
    private bool isAlive;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        currentHealth = startingHealth;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (!GameManager.instance.GameOver)
        {
            if(other.tag == "PlayerWeapon")
            {
                TakeHit();
            }
        }
    }

    void TakeHit()
    {
        if(currentHealth > 0)
        {
            GameObject newExplosionEffect = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(newExplosionEffect, 1);
            currentHealth -= 10;
        }
        if(currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        sphereCollider.enabled = false;
        Destroy(gameObject);
    }
}
