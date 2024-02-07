using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlCollision : DetectCollisions
{
    private AudioSource onTriggerAudio;


    protected override void OnTriggerEnter(Collider other) //Using overrrid method to override the parent class: DetectCollisions script
    {

        //base.OnTriggerEnter(other);

        if (other.tag == "Fish")
        {
            Debug.Log("Is this working?");
        }

    }
}
