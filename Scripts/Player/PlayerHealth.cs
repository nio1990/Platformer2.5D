using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int startingHealth = 100;
    [SerializeField] float timeSinceLastHit = 2f;
    [SerializeField] int currentHealth;
    [SerializeField] private float timer = 0f;
    [SerializeField] Slider healthBar;
    public bool isDead;
    private Animator anim;
    private CharacterMovement characterMovement;
    private new AudioSource audio;
    public AudioClip hurtAudio;
    public AudioClip deathAudio;
    public AudioClip pickItem;
    public Slider HealthBar
    {
        get { return healthBar; }
    }
    public float Timer
    {
        get { return timer; }
        set { timer = 0; }
    }
    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if (value < 0)
            {
                currentHealth = 0;
            }
            else
            {
                currentHealth = value;
            }
        }
    }


    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
        characterMovement = GetComponent<CharacterMovement>();
        audio = GetComponent<AudioSource>();

        levelManager = FindObjectOfType<LevelManager>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        PlayerKill();
    }

    void OnTriggerEnter(Collider other)
    {
        if(timer >=timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if(other.tag == "Weapon")
            {
                TakeHit();
                timer = 0;
            }else if(other.tag == "Boss")
            {

                TakeHit();
                timer = 0;
            }
        }
    }

    public void TakeHit()
    {
        if(currentHealth > 0)
        {
            GameManager.instance.PlayerHit(currentHealth);
            anim.Play("Player_Hurt");
            currentHealth -= 10;
            healthBar.value = currentHealth;
            audio.PlayOneShot(hurtAudio);
        }
        if (currentHealth <= 0)
        {
            //GameManager.instance.PlayerHit(currentHealth);
            anim.SetTrigger("isDead");
            characterMovement.enabled = false;
            audio.PlayOneShot(deathAudio);
        }
        
    }

    public void PowerUpHealth()
    {
        if(currentHealth <= 80)
        {
            currentHealth += 20;
            
        }
        else if(currentHealth < startingHealth)
        {
            currentHealth = startingHealth;
        }
        healthBar.value = currentHealth;
        audio.PlayOneShot(pickItem);
    }

    public void KillBox()
    {
        CurrentHealth = 0;
        healthBar.value = currentHealth;
    }

    public void PlayerKill()
    {
        if(currentHealth <= 0)
        {
            characterMovement.enabled = false;
            levelManager.RespawnPlayer();
        }
    }

}
