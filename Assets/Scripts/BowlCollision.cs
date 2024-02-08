using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
