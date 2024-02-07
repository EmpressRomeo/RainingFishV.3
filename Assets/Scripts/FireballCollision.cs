using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollision : DetectCollisions //CHILD CLASS - INHERITANCE
{


    protected override void OnTriggerEnter(Collider other) //POLYMORPHISM - Using override method to override parent class: DetectCollisions script
    {
        base.OnTriggerEnter(other);

        gameManager.SubtractScore(); //changed from AddScore() to SubtractScore()        
    }
}
