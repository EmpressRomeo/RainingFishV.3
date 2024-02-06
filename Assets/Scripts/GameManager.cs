using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour //This Script is attached to an empty game object named "GameManger"
{
    public bool gameIsActive; //referenced in FallingObjects Script
    

    [SerializeField] float timeRemaining; //GameTimer
    [SerializeField] TextMeshProUGUI timerText; //GameTimer

    [SerializeField] TextMeshProUGUI gameOverText; //GameOver

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer();
    }

    public void GameTimer()
    {
        if (gameIsActive)
        {
            timeRemaining -= Time.deltaTime;
            timerText.SetText("Time: " + Mathf.Round(timeRemaining));
            if (timeRemaining < 0)
            {
                GameOver();
            }
        }
    }

    


    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameIsActive = false;
    }
}
