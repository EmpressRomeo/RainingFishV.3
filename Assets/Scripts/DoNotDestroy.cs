using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO; //class SaveData

public class DoNotDestroy : MonoBehaviour
{
    public static DoNotDestroy Instance;

    
    public TMP_InputField inputField; //SetPlayerName()
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


    }
    public void SetPlayerName() //Set our player_name to be equal to what is entered in inputfield in MainMenu scene
    {
        playerName = inputField.text;
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
    }

    public void SavePlayerName() //method that transforms SaveData class into JSON format and writes it to a file
    {
        SaveData data = new SaveData();
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + ".savefile.sjon", json);
    }

    public void LoadPlayerName() //method that transforms the data from JSON file 
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
        }
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
