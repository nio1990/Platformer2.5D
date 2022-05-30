using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private bool gameOver = false;
    public static GameManager instance = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }

    public GameObject Player
    {
        get
        {
            return player;
        }
    }
    public bool GameOver
    {
        get
        {
            return gameOver;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayerHit (int currentHP)
    {
        if(currentHP > 0)
        {
            gameOver = false;
        }
        else
        {
            gameOver = true;
        }
    }
}
