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

    public string name; //SetPlayerName()

    private AudioSource gameMusic; //PlayMusic()

 

    private string file = "player.txt";

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

        Load(); //Make sure this is at the end of Awake()
    }

    private void Start()
    {

        mainMenuManager = GameObject.Find("MainMenuCanvas").GetComponent<MainMenuManger>(); //Initialize MainMenuManager using the Find() method
    }

    public void SetPlayerName()
    {
        name = mainMenuManager.playerName.text;
    }
    //public void SetPlayerName() //Set our player_name to be equal to what is entered in inputfield in MainMenu scene
    //{
    // playerName = mainMenuManager.nameInputField.text;
    // }


    //[System.Serializable]
    //  class SaveData //this is PlayerData
    //  {
    // public string playerName;
    // }
    [System.Serializable]
    class PlayerData
        {
        public string name; 
        }


    public void Save() 
    {
        PlayerData data = new PlayerData();
        data.name = name;
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json); 
        //SaveData data = new SaveData();

        //data.playerName = playerName;

        //string json = JsonUtility.ToJson(data);

       //File.WriteAllText(Application.persistentDataPath + ".savefile.json", json);
    }

    public void Load() //Load from JSON
    {
        PlayerData data = new PlayerData();
        data.name = name; 
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data); 

        //string path = Application.persistentDataPath + "/savefile.json";
        //if (File.Exists(path))
        //{
          //  string json = File.ReadAllText(path);
          //  SaveData data = JsonUtility.FromJson<SaveData>(json);

           // playerName = data.playerName;
       // }
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create); 

        using(StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json); 
        }
    }
    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
            Debug.LogWarning("File no found!");
        return ""; 
    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName; 
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
