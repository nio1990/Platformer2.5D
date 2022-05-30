using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLimit : MonoBehaviour
{
    public new BoxCollider collider;
    private BossController bossController;
    private CharacterMovement characterMovement;
    private Animator playerAnimator;
    private SmoothFollow smoothFollow;
    public AudioClip newTrack;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
        characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        smoothFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SmoothFollow>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (newTrack != null)
            {
                audioManager.ChangeMusic(newTrack);
            }
            collider.isTrigger = false;
        }
    }
}
