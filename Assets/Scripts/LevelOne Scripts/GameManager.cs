using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool gameIsActive;

    [SerializeField] TextMeshProUGUI displayPlayerName;

    //SpawnFallingPrefabs
    [SerializeField] GameObject[] fallingPrefabs;
    private float spawnRange = 6.0f;
    private float spawnPosY = 6.0f;
    private float spawnPosZ = -2.0f;
    private float startDelay = 1.0f;
    private float spawnInterval = 0.5f;

    //GameTimer
    [SerializeField] float timeRemaining;
    [SerializeField] TextMeshProUGUI timerText;

    //UpdateScore
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScore; 
    private int score; 

    //GameOver
    [SerializeField] TextMeshProUGUI gameOverText;

    void Awake()
    {
        if (DoNotDestroy.Instance != null)
        {
            displayPlayerName.text = DoNotDestroy.Instance.playerName;
        }

        InvokeRepeating("SpawnFallingPrefabs", startDelay, spawnInterval);

        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        GameTimer(); //ABSTRACTION
    }

    public int Score //ENCAPSULATION - create a property by adding a get/set accessor to "score" variable
    {
        get
        {
            return score;
        }

        set
        {
            if (value < 0)
            {
                score = 0;
            }
            else
            {
                score = value;
            }
        }
    }

    public void SubtractScore()
    {
        Score -= 5; //ENCAPSULATION - using property "Score", NOT the variable to ensure score does not become negative number

        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();

        SaveHighScore();
    }

    private void SaveHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = "High Score: " + score.ToString();
        }

    }
 
    private void GameTimer() //ABSTRACTION
    {
        if (gameIsActive)
        {
            timeRemaining -= Time.deltaTime;
            timerText.SetText("Time: " + Mathf.Round(timeRemaining));
            if (timeRemaining < 0)
            {
                GameOver();
            }
        }
    }

    private void SpawnFallingPrefabs()
    {
        if (gameIsActive) 
        {
            int fallingPrefabsIndex = Random.Range(0, fallingPrefabs.Length); 

            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), spawnPosY, spawnPosZ); 

            Instantiate(fallingPrefabs[fallingPrefabsIndex], spawnPos, fallingPrefabs[fallingPrefabsIndex].transform.rotation); 
        }
    }

    private void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameIsActive = false;
    }


   



    //Click Reset High Score button, note this is for testing only and will not be visible in playmode
    public void Reset() 
    {
        PlayerPrefs.DeleteKey("HighScore"); 
        highScore.text = "High Score: 0";
    }


}
