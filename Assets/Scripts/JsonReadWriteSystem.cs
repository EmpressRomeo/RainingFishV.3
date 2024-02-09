
using System.IO; 
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class JsonReadWriteSystem : MonoBehaviour
{
    public TMP_InputField nameInputField;

    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
    }

    public void SaveToJson()
    {
        PlayerData data = new PlayerData();
        data.playerName = nameInputField.text;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + ".savefile.json", json);

        Debug.Log("Saved Player Name:" + data.playerName); 
    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.persistentDataPath + ".savefile.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);

        nameInputField.text = data.playerName;

        Debug.Log("Load Successfl"); 
    }
}
