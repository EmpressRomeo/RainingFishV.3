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
    //public TMP_InputField nameInputField; //SetPlayerName()

    [SerializeField] TMP_InputField nameInput; //NEW NEW


    List<InputEntry> entries = new List<InputEntry>(); //NEW NEW Use the constructor that we create in InputEntry class script

    public void AddNameToList() //NEW NEW INPUT HANDLER
    {
        entries.Add(new InputEntry (nameInput.text, Random.Range (0, 100))); //note random range is just a random #, will update to score later
        nameInput.text = ""; 
    }

    private void Start()
    {

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
