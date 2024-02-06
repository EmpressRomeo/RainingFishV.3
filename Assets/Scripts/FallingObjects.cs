using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [SerializeField] GameObject[] fallingPrefabs; // make sure to assign prefabs to array in inspector

    private float spawnRangeRight = 6.0f; //SpawnFallingPrefabs
    private float spawnRangeLeft = -6.0f; //SpawnFallingPrefabs
    private float spawnPosY = 6.0f; //SpawnFallingPrefabs
    private float spawnPosZ = -2.0f; //SpawnFallingPrefabs
    private float startDelay = 1.0f; //SpawnFallingPrefabs
    private float spawnInterval = 1.0f; //SpawnFallingPrefabs

    private GameManager gameManager; //variable creates a reference to GameManager script

    private AudioSource groundCollisionAudio; //OnCollissionEnter
    [SerializeField] AudioClip puffSound; //OnCollissionEnter
    private float soundLength = 1.0f; //OnCollissionEnter
    [SerializeField] ParticleSystem puffParticle; //OnCollissionEnter
    private float delayDestroy = 0.5f; //OnCollissionEnter

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //initializes GameManager script using Find() method

        groundCollisionAudio = GetComponent<AudioSource>();

        puffParticle.Stop();

        StartLevelOne();
    }

    public void SpawnFallingPrefabs()
    {
        if (gameManager.gameIsActive) //falling prefabs will only spawn when gameIsActive = true, note gameIsActive is located in GameManager script
        {
            int fallingPrefabsIndex = Random.Range(0, fallingPrefabs.Length); //create fallingPrefabsIndex integer variable so that we can call random falling objects 1, 2, and 3 in our array


            Vector3 spawnPos = new Vector3(Random.Range(spawnRangeLeft, spawnRangeRight), spawnPosY, spawnPosZ); //create spawnPos variable so that falling prefabs will spawn in random place on x axis at the top of the screen


            Instantiate(fallingPrefabs[fallingPrefabsIndex], spawnPos, fallingPrefabs[fallingPrefabsIndex].transform.rotation); //Use instantiate method to create clones of the prefabs for spawning
        }
    }

    protected void StartLevelOne()
    {
        InvokeRepeating("SpawnFallingPrefabs", startDelay, spawnInterval);  //SpawnFallingPrefabs
    }

}
