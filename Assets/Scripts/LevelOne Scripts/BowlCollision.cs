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
            splashParticle.Play();
            bowlAudio.PlayOneShot(splashSound, soundLength); 
        }
        else
        {
            explosionParticle.Play(); 
            bowlAudio.PlayOneShot(explosionSound, soundLength); 
        }

    }
}
