using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour //PARENT CLASS - INHERITANCE
{
    protected GameManager gameManager; //create a reference to GameManager

    public float delayDestroy = 0.1f;
    public float soundlength = 1.0f;
    private AudioSource collisionAudio;

    //Variables that play when falling prefabs hit the ground
    public AudioClip groundSound;
    public ParticleSystem groundParticle;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //Initialize GameManager using the Find() method 
        collisionAudio = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundParticle.Play();
            collisionAudio.PlayOneShot(groundSound, soundlength);
            Destroy(gameObject, delayDestroy);
        }

    }
    protected virtual void OnTriggerEnter(Collider other) //Using virtual method to enable overriding in child class: FireballCollision script
    {
        if (other.tag == "Bowl")
        {
            gameManager.AddScore();
            Destroy(gameObject);
        }
    }
}
