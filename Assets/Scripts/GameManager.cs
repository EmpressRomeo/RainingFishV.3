using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public bool gameIsActive; 
    
    public GameObject[] fallingPrefabs; //variable for fish & fireball prefabs, make sure to assing prefabs to array in inspector

    [SerializeField] float spawnRangeRight; //SpawnFallingPrefabs
    [SerializeField] float spawnRangeLeft; //SpawnFallingPrefabs
    [SerializeField] float spawnPosY; //SpawnFallingPrefabs
    [SerializeField] float spawnPosZ; //SpawnFallingPrefabs
    public float startDelay = 1.0f; //SpawnFallingPrefabs
    public float spawnInterval; //SpawnFallingPrefabs


    [SerializeField] float timeRemaining; //GameTimer
    public TextMeshProUGUI timerText; //GameTimer


    public TextMeshProUGUI gameOverText; //GameOver
    



    // Start is called before the first frame update
    void Start()
    {
        StartLevelOne(); 
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer();
    }

    public void GameTimer()
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

    public void SpawnFallingPrefabs()
    {
        if (gameIsActive) //falling prefabs will only spawn when isGameActive = true
        {
            int fallingPrefabsIndex = Random.Range(0, fallingPrefabs.Length); //create fallingPrefabsIndex integer variable so that we can call random falling objects 1, 2, and 3 in our array


            Vector3 spawnPos = new Vector3(Random.Range(spawnRangeLeft, spawnRangeRight), spawnPosY, spawnPosZ); //create spawnPos variable so that falling prefabs will spawn in random place on x axis at the top of the screen


            Instantiate(fallingPrefabs[fallingPrefabsIndex], spawnPos, fallingPrefabs[fallingPrefabsIndex].transform.rotation); //Use instantiate method to create clones of the prefabs for spawning
        }
    }

    public void StartLevelOne()
    {
        InvokeRepeating("SpawnFallingPrefabs", startDelay, spawnInterval);  //SpawnFallingPrefabs
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameIsActive = false;
    }
}
