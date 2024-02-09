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
    [SerializeField] Canvas howToPlayScreen;

    //SetPlayerName in DoNotDestroy script
    public TMP_InputField nameInputField; 


    public void ClickStart()
    {  
        SceneManager.LoadScene(1);
    }

    //When player clicks the How To Play button, instructions will appear
    public void ClickHowToPlay() 
    {
        howToPlayScreen.gameObject.SetActive(true); 
    }

    //When player clicks the "X" Button they will close out the instructions
    public void ClickExit() 
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
