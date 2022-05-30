using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03Movement : MonoBehaviour
{
    [SerializeField] private int startingHealth = 10;
    [SerializeField] private int currentHealth;
    public float moveSpeed;
    private new Rigidbody rigidbody;
    private Transform transform;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHealth >= startingHealth)
        {
            Vector2 Vel = rigidbody.velocity;
            Vel.x = -moveSpeed;
            rigidbody.velocity = Vel;
        }else
        {
            Vector2 Vel = rigidbody.velocity;
            Vel.x = 0;
        }
    }
}
