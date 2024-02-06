using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollissions : MonoBehaviour
{
    [SerializeField] float delayDestroy; //Fish will be destroyed upon hitting the ground after a small delay
    public ParticleSystem puffParticle; //Puff of snow will appear when fish hit the ground
    private AudioSource fishAudio;
    public AudioClip puffSound; //Sound will activate when fish hit the ground

    // Start is called before the first frame update
    void Start()
    {
        puffParticle.Stop();
        fishAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            puffParticle.Play();
            fishAudio.PlayOneShot(puffSound, 1.0f);
            Destroy(gameObject, delayDestroy); //When fish hit the ground they will be destroyed
        }
    }
}
