using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//ClickQuit()
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManger : MonoBehaviour
{
    public Canvas howToPlayScreen;

   public TMP_InputField playerName; //SetPlayerName()

    public DoNotDestroy dataManager; //will change to do not destroy later

    private void Start()
    {
        dataManager.Load();
        playerName.text = dataManager.name; 
    }

    public void ChangePlayerName(string text)
    {
        dataManager.name = text;  
    }
    public void ClickStart()
    {
        DoNotDestroy.Instance.SetPlayerName();  
       
        SceneManager.LoadScene(1);
    }

    public void ClickHowToPlay() //When player clicks the How To Play button, instructions will appear
    {
        howToPlayScreen.gameObject.SetActive(true); 
    }

    public void ClickExit() //When player clicks the "X" Button they will close out the instructions
    {
        howToPlayScreen.gameObject.SetActive(false); 
    }

    public void ClickQuit() 
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }
}
