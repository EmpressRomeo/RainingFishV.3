using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    public static DoNotDestroy Instance;

    //Reference to MainMenuManager Script
    private MainMenuManger mainMenuManager; 

    //SetPlayerName
    public string playerName; 

    //PlayMusic
    private AudioSource gameMusic; 

    private void Awake()
    {
        //This code ensures our game object isn't destroyed between scenes
        //It also uses the "singleton" method to ensure there is only one of these game objects in each scene 
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        PlayMusic();
        gameMusic = GetComponent<AudioSource>();
    }

    private void Start()
    {
        //Initialize MainMenuManager using the Find() method
        mainMenuManager = GameObject.Find("MainMenuCanvas").GetComponent<MainMenuManger>(); 
    }

    public void SetPlayerName() 
    {
        playerName = mainMenuManager.nameInputField.text;
    }

    private void PlayMusic()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1) 
        {
            Destroy(this.gameObject); 
        }
    }
}
