using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour //PARENT CLASS - INHERITANCE
{
    //Reference to GameManager script
    protected GameManager gameManager; 

    private float delayDestroy = 0.4f;
    private float soundlength = 1.0f;
    private AudioSource collisionAudio;

    //Variables that play when falling prefabs hit the ground
    [SerializeField] AudioClip groundSound;
    [SerializeField] ParticleSystem groundParticle;

    private void Start()
    {
        //Initialize GameManager using the Find() method
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();  
        collisionAudio = GetComponent<AudioSource>();
    }

    //POLYMORPHISM - Using virtual method to enable overriding in child class: FireballCollision script
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bowl")
        {
            gameManager.AddScore();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundParticle.Play();
            collisionAudio.PlayOneShot(groundSound, soundlength);
            Destroy(gameObject, delayDestroy);
        }

    }

    
}
