using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Un meilleur Vroum vroum

// Controles:
// Roues à l'arret:
// Fleche du haut pour avancer (acceleration des roues jusqu'a la vitesse moveSpeed)
// Fleche du bas pour reculer (acceleration des roues dans le sens inverse jusqu'a la vitesse moveSpeed/4)
// Fleche du bas avec roues tournant vers l'avant ou fleche du haut avec roues tournant vers l'arriere:
// Freinage jusqu'à l'arret
// Touche gauche/droite: orientation des roues
// Avancée/recul avec roues en position gauche/droite: tourner (angle de 30°, tout ou rien, par défaut)


public class playerMovementCar : MonoBehaviour
{
    //Static acceleration variable
    public float moveAcc = 40f;
    //Movement speed of the player car.
    public float moveSpeed = 50f;
    //Rotation speed of the player car.
    public float rotaSpeed = 5f;
    //Time it takes for the car's wheels to stop on their own
    public float stoptime = 2.0f;
    // Rigid body of the player.
    public Rigidbody2D rigidBody;
    // Vector which stores two values between -1 and 1 corresponding to the X axis and Y axis.
    Vector2 input;
    // Angle of the wheels, between 0 and 120.
    int whangle = 30;
    // Speed of the wheels
    float whspeed = 0.0f;

    // Start is called before the first frame update.
    private void Start()
    {
        //check if there is a rigidbody ( if the variable is != to null)
        if (!rigidBody)
        {
            //Look on the object if there is a Rigidbody2D and if so then take it as a reference.
            //it is slow so don't do this every frame.

            rigidBody = GetComponent<Rigidbody2D>();
            //Setting the rigidbody's drag while we're at it
            rigidBody.drag = 5;
        }
    }

    // Update is called once per frame.
    void Update()
    {
        // Get a value between -1 and 1. 0 if no keys pressed.
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        whangle = 30;

        // This is where the sausage is made. Rotation sausage.
        if (whangle + (int)input.x >= 0 && whangle + (int)input.x < 60)
            whangle = whangle + ((int)input.x*15);
    }
    // Update function called once per tick.
    private void FixedUpdate()
    {
        // Vector storing the instantaneous acceleration
        Vector2 m_Mvt;
        Vector2 m_Sdr;
        m_Sdr.x = 0.0f; m_Sdr.y = 0.0f;


        // Increment wheel speed
        if (input.y == 0)
            whspeed *= (1 - (1 / stoptime) * Time.fixedDeltaTime);
        else if ((input.y < 0 && whspeed > 0)|| (input.y > 0 && whspeed < 0))
            whspeed *= 0.1f * Time.fixedDeltaTime;
        else if (input.y > 0 && whspeed >= 0)
            whspeed += input.y * moveAcc * (1 - Mathf.Abs(whspeed) / moveSpeed) * Time.fixedDeltaTime;
        else
            whspeed += input.y * moveAcc * (1 - Mathf.Abs(whspeed) / moveSpeed) * Time.fixedDeltaTime / 4;

        // Move player
        rigidBody.rotation -= ((whangle-30) * rotaSpeed) * (whspeed / moveSpeed) * Time.fixedDeltaTime;
        m_Mvt.x = (whspeed * -Mathf.Sin(rigidBody.rotation * Mathf.Deg2Rad));
        m_Mvt.y = (whspeed *  Mathf.Cos(rigidBody.rotation * Mathf.Deg2Rad));
        


        //defunct slowdown algorithm
        //m_Sdr.x = (50*rigidBody.velocity.x * ( Mathf.Cos(rigidBody.rotation * Mathf.Deg2Rad))) *Time.fixedDeltaTime;
        //m_Sdr.y = (50*rigidBody.velocity.y * (-Mathf.Sin(rigidBody.rotation * Mathf.Deg2Rad))) *Time.fixedDeltaTime;


        rigidBody.velocity += (m_Mvt * Time.fixedDeltaTime);


    }
}
