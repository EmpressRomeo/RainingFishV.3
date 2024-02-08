using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Initially wanted to do this all in the DetectCollisions script. I wanted prefabs to be destroyed instantly when they 
//collided with the bowl, however once an object is destroyed so are any particles/sounds attached to it.
//Therefore, to have the particles/sounds play without being cutoff I created this BowlCollision script. 
public class BowlCollision : MonoBehaviour 
{
    private AudioSource bowlAudio;
    public AudioClip splashSound; 
    public AudioClip explosionSound; 
    public ParticleSystem splashParticle; 
    public ParticleSystem explosionParticle;
    [SerializeField] float soundLength = 1.0f; 

    void Start()
    {
        bowlAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fish")
        {
            splashParticle.Play(); //when fish collide with bowl splash particle will appear
            bowlAudio.PlayOneShot(splashSound, soundLength); //when fish collide with bowl splash sound will play
        }
        else
        {
            explosionParticle.Play(); //when fireball collides with bowl explosion particle will appear
            bowlAudio.PlayOneShot(explosionSound, soundLength); //when fireball collides with bowl explosion sound will play
        }

    }
}
