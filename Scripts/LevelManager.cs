using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static Vector3 checkPoint;
    public float timer = 0f;
    public float waitTime = 2.0f;
    public GameObject currentCheckpoint;
    private GameObject player;
    private PlayerHealth playerHealth;
    private CharacterMovement characterMovement;
    public PlayerHealth playerSlider;
    public Animator anim;

    private LifeManager lifeSystem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.Player;
        playerHealth = player.GetComponent<PlayerHealth>();
        characterMovement = player.GetComponent<CharacterMovement>();
        playerSlider = player.GetComponent<PlayerHealth>();
        anim = player.GetComponent<Animator>();
        lifeSystem = FindObjectOfType<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            timer = 0f;
            player.transform.position = currentCheckpoint.transform.position;
            playerHealth.CurrentHealth = 100;
            characterMovement.enabled = true;
            playerHealth.HealthBar.value = playerHealth.CurrentHealth;

            anim.Play("Blend Tree");

            lifeSystem.TakeLife();
        }
        
    }
}
