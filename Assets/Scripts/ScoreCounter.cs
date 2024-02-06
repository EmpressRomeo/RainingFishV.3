using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class ScoreCounter : MonoBehaviour //This Script is attached to Bowl which is a child of Player game object 
{
    public int score; //AddScore()
    public TextMeshProUGUI scoreText; //AddScore()
    public TextMeshProUGUI highScore; //AddScore()

    public ParticleSystem splashParticle; //OnTriggerEnter(Collider other)
    public ParticleSystem explosionParticle; //OnTriggerEnter(Collider other)

    private AudioSource bowlAudio; //OnTriggerEnter(Collider other)
    public AudioClip splashSound; //OnTriggerEnter(Collider other)
    public AudioClip explosionSound; //OnTriggerEnter(Collider other)


    // Start is called before the first frame update
    void Start()
    {
        bowlAudio = GetComponent<AudioSource>();
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        explosionParticle.Stop();
        splashParticle.Stop(); 
    }

    private void AddScore() //Counts the number of fish collected by the player
    {
        score++;
        scoreText.text = "Score: " + score.ToString(); 

        SaveHighScore();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Fish")
        { 
            AddScore();
            splashParticle.Play(); //when fish collide with bowl splash particle will appear
            bowlAudio.PlayOneShot(splashSound, 1.0f); //when fish collide with bowl splash sound will play
            Destroy(other.gameObject); //Destroys fish that collide with bowl 
        }
        else
        {
            score = 0;
            scoreText.text = "Score: " + score.ToString(); 
            explosionParticle.Play(); //when fireball collides with bowl explosion particle will appear
            bowlAudio.PlayOneShot(explosionSound, 1.0f); //when fireball collides with bowl explosion sound will play
            Destroy(other.gameObject); //Destroys fireballs that collide with bowl
        }
       
    }

    private void SaveHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score); //this line saves the player's score to the computer
            highScore.text = "High Score: " + score.ToString();
        }

    }

    public void Reset() //Click Rest High Score button to reset the High Score to zero
    {
        PlayerPrefs.DeleteKey("HighScore"); //use to delete HighScore to 0
        highScore.text = "High Score: 0";
    }
}
