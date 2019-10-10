using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //Movement speed of the player car
    public float moveSpeed = 5f;
    // Rigid body of the player
    public Rigidbody2D rigidBody;
    //Vector which stores two values between -1 and 1 corresponding to the X axis and Y axis.
    Vector2 movement;
    //On begin play
    private void Start()
    {
        //check if there is a rigidbody ( if the variable is != to null)
        if (!rigidBody)
        {
            //Look on the object if there is a Rigidbody2D and if so then take it as a reference.
            //it is slow so don't do this every frame.

            rigidBody = GetComponent<Rigidbody2D>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Get a value between -1 and 1. 0 if no keys pressed.
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    //Update function but which append on a fixed time.
    private void FixedUpdate()
    {
        //Move player
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
