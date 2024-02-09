using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//ClickQuit()
#if UNITY_EDITOR 
using UnityEditor; 
#endif               

public class ButtonScript : MonoBehaviour
{
    private GameManager gameManager; //create a reference to GameManager

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //Initialize GameManager using the Find() method 
    }

    public void ClickRestart()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickQuit() 
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }
    
    public void ClickRestHighScore()
    {
        gameManager.Reset(); 
    }
    
   
}
