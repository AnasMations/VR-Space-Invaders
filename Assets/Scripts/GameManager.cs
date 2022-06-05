using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Player;
    public int Score;
    public int HighScore;
    public int PlayerHealth;

    public GameObject GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    void GameOver()
    {
        if(PlayerHealth<=0)
        {
            Player.GetComponent<PlayerSpaceship>().PlayerSpeed = 0;
            Player.GetComponent<PlayerSpaceship>().isShooting = false;
            GameOverScreen.SetActive(true);
            if(Score > HighScore)
            {
                HighScore = Score;
            }
        }
    }

    void Replay()
    {

    }

}
