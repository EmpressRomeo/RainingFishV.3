using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManger : MonoBehaviour
{
    public Canvas howToPlayScreen;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickHowToPlay() //When player clicks the How To Play button, instructions will appear
    {
        howToPlayScreen.gameObject.SetActive(true); 
    }

    public void ClickExit() //When player clicks the X Button they will close out the instructions
    {
        howToPlayScreen.gameObject.SetActive(false); 
    }

    public void ClickQuit() //When player clicks the Quit Button they will exit the application
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }
}
