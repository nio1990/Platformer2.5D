using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public int startingLives;
    private int lifeCounter;
    private Text lifeText;
    private GameObject player;
    public GameObject gameOverScreen;
    public float waitAfterGameOver;
    public GameObject bossHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        lifeText = GetComponent<Text>();
        lifeCounter = startingLives;
        player = GameManager.instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "x " + lifeCounter;
        if(lifeCounter <= 0)
        {
            gameOverScreen.SetActive(true);
            player.gameObject.SetActive(false);
            bossHealthBar.SetActive(false);
        }
        if (gameOverScreen.activeSelf)
        {
            waitAfterGameOver -= Time.deltaTime;
        }
        if(waitAfterGameOver < 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void GiveLife()
    {
        lifeCounter++;
    }

    public void TakeLife()
    {
        lifeCounter--;
    }
}
