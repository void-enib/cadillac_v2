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
        if (!rigidBody)
        {
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
