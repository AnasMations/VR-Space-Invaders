using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject Player;
    public int Score;
    public int HighScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public float PlayerMaxHealth;
    public float PlayerHealth;
    public Slider healthBar;

    public GameObject GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.Find("Player");
        PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("HighScore", 0));
        HighScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = PlayerHealth / PlayerMaxHealth;
        scoreText.text = "Score: " + Score.ToString();
        highScoreText.text = "High Score: " + HighScore.ToString();
        GameOver();
    }

    void GameOver()
    {
        if(PlayerHealth<=0)
        {
            Player.GetComponent<PlayerSpaceship>().PlayerSpeed = 0;
            Player.GetComponent<PlayerSpaceship>().isShooting = false;
            if(Score > HighScore)
            {
                HighScore = Score;
                PlayerPrefs.SetInt("HighScore", HighScore);
            }
            GameOverScreen.SetActive(true);
            //wait and reload scene
            StartCoroutine("Retry");
        }

    }

    IEnumerator Retry()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("SpaceScene");
    }

}
