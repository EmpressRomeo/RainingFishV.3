using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //This Script is attached to Player game object 
{
    public float moveSpeed; //MovePlayer()
    public float rotationSpeed; //MovePlayer()

    private Rigidbody playerRb; //AnimatePlayer
    private Animator playerAnim; //AnimatePlayer

    private Vector3 pos; //ScreenBoundary()
    private float leftBoundary = -6.0f; //ScreenBoundary()
    private float rightBoundary = 6.0f; //ScreenBoundary()


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); 
        playerAnim = GetComponent<Animator>();


        //screenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Camera.main.transform.position.y, Camera.main.transform.position.z));
       
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ScreenBoundary(); 
    }

    public void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //create variable to call player input for left & right arrow keys

        Vector3 movementDirection = new Vector3(horizontalInput, 0, 0); //create variable to call movement along the x-axis using horizontalInput 
        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);//move player left and right in our scene

        if (movementDirection != Vector3.zero) //if movementDirection does not equal 0, then rotate player in the direction of movementDirection
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }

        //AnimatePlayer
        if (movementDirection != Vector3.zero)
        {
            playerAnim.SetBool("Running", true);
        }
        else
            playerAnim.SetBool("Running", false);
    }

    private void ScreenBoundary()
    {
        pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, leftBoundary, rightBoundary);
        transform.position = pos;
    }
}
