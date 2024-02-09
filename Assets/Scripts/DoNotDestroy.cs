using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO; //class SaveData

public class DoNotDestroy : MonoBehaviour
{
    public static DoNotDestroy Instance;

    //public TMP_InputField nameInputField; //SetPlayerName()
    //public string playerName; //SetPlayerName()

    private MainMenuManger mainMenuManager; //create a reference to MainMenuManager Script

    public string playerName; //SetPlayerName()

    private AudioSource gameMusic; //PlayMusic()

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

        LoadPlayerName(); //Make sure this is at the end of Awake()
    }

    private void Start()
    {

        mainMenuManager = GameObject.Find("MainMenuCanvas").GetComponent<MainMenuManger>(); //Initialize MainMenuManager using the Find() method
    }

    public void SetPlayerName() //Set our playerName to be equal to what is entered in inputfield in MainMenu scene
    {
        playerName = mainMenuManager.nameInputField.text;
      
    }

    //*******JSON*******
    //1. Create serializable class to describe variable(s) we want to store in JSON data
    [System.Serializable] 
    public class SaveData
    {
        public string playerName;
    }

    //*******Save to JSON*******
    public void SavePlayerName() 
    {
        //2. Creates an instance of your class 
        SaveData data = new SaveData(); 
        data.playerName = playerName;   
       
        //3. Use JsonUtility.ToJson method to serialize it (convert it) to JSON format
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + ".savefile.json", json);

        //4. JSON now contains '{"playerName": "playerName"}'
    }

    //*******Load from JSON*******
    public void LoadPlayerName() 
    {
        //5. Check to see if the save file path exists
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            //6. If the path exists convert JSON format back into an object
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
        }
    }

    public void OverwritePlayerName()
    {
        JsonUtility.FromJsonOverwrite(json, data);
    }

    private void PlayMusic()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1) //If there is more than one music object
        {
            Destroy(this.gameObject); //then destroy this gameobject, this is "singleton" method to ensure there is only one in game
        }
    }
}
