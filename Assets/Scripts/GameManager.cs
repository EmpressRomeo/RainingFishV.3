using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour //This Script is attached to an empty game object named "GameManger"
{
    public bool gameIsActive; 

    [SerializeField] GameObject[] fallingPrefabs; // make sure to assign prefabs to array in inspector

    private float spawnRangeRight = 6.0f; //SpawnFallingPrefabs
    private float spawnRangeLeft = -6.0f; //SpawnFallingPrefabs
    private float spawnPosY = 6.0f; //SpawnFallingPrefabs
    private float spawnPosZ = -2.0f; //SpawnFallingPrefabs
    private float startDelay = 1.0f; //SpawnFallingPrefabs
    private float spawnInterval = 1.0f; //SpawnFallingPrefabs

    [SerializeField] float timeRemaining; //GameTimer
    [SerializeField] TextMeshProUGUI timerText; //GameTimer

    [SerializeField] TextMeshProUGUI gameOverText; //GameOver

    public int score; //UpdateScore()
    public TextMeshProUGUI scoreText; //UpdateScore()
    public TextMeshProUGUI highScore; //UpdateScore()

    // Start is called before the first frame update
    void Start()
    {
        StartLevelOne();
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer();
    }

    private void StartLevelOne()
    {
        InvokeRepeating("SpawnFallingPrefabs", startDelay, spawnInterval);  //SpawnFallingPrefabs
    }

    private  void GameTimer()
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
        if (gameIsActive) //falling prefabs will only spawn when gameIsActive = true, note gameIsActive is located in GameManager script
        {
            int fallingPrefabsIndex = Random.Range(0, fallingPrefabs.Length); //create fallingPrefabsIndex integer variable so that we can call random falling objects 1, 2, and 3 in our array


            Vector3 spawnPos = new Vector3(Random.Range(spawnRangeLeft, spawnRangeRight), spawnPosY, spawnPosZ); //create spawnPos variable so that falling prefabs will spawn in random place on x axis at the top of the screen


            Instantiate(fallingPrefabs[fallingPrefabsIndex], spawnPos, fallingPrefabs[fallingPrefabsIndex].transform.rotation); //Use instantiate method to create clones of the prefabs for spawning
        }
    }

    private void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameIsActive = false;
    }

    public void AddScore() //Counts the number of fish collected by the player
    {
        score++;
        scoreText.text = "Score: " + score.ToString();

        SaveHighScore();
    }

    public void SubtractScore() //Resets score to zero if fireball hits player
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }
    

    private void SaveHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score); //this line saves the player's score to the computer
            highScore.text = "High Score: " + score.ToString();
        }

    }

    public void Reset() //Click Rest High Score button to reset the High Score to zero
    {
        PlayerPrefs.DeleteKey("HighScore"); //use to delete HighScore to 0
        highScore.text = "High Score: 0";
    }


}
