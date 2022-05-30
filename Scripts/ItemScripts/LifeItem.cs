using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItem : MonoBehaviour
{
    private GameObject player;
    private AudioSource audio;
    private LifeManager lifeManager;
    private SpriteRenderer spriteRenderer;
    private BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.Player;
        lifeManager = FindObjectOfType<LifeManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            PickLife();
        }
    }

    public void PickLife()
    {
        lifeManager.GiveLife();
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        Destroy(gameObject);
    }
}
