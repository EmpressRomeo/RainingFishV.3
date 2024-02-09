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

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //Initialize GameManager using the Find() method 
    }

    private void ClickRestart()
    {
        SceneManager.LoadScene(1);
    }

    private void ClickQuit() 
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }

    private void ClickRestHighScore()
    {
        gameManager.Reset(); 
    }
    
   
}
