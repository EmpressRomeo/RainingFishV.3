using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollision : DetectCollisions //CHILD CLASS - INHERITANCE
{

    //POLYMORPHISM - Using override method to override parent class: DetectCollisions script
    protected override void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Bowl")
        {
            gameManager.SubtractScore(); //changed from AddScore() to SubtractScore()
            Destroy(gameObject);
        }
    }
}
