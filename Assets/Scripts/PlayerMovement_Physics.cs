using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Physics : MonoBehaviour
{
    public float acceleration;
    public float decceleration;
    public bool moving;

    public float t;
    public float rR;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("CheckSpeed", t, rR);
    }

    void FixedUpdate()
    {
        Movement();
        MovementDecceleration();
    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal"); // GetAxis suma 0.05f, GetAxisRaw suma 1.
        float moveVertical = Input.GetAxis ("Vertical");

        //if(rb.velocity.x != 0 | rb.velocity.y != 0 | rb.velocity.z != 0) // Comprueba las velocidades, rara vez se quedan a 0.
        //if (moveHorizontal < 0.0f | moveVertical < 0.0f) // Comprueba los valores, al cabo de un segundo de dejar de pulsar se quedan en 0.
        if (Input.GetAxis("Horizontal") != 0.0f | Input.GetAxis("Vertical") != 0.0f) // Comprueba si hay input, perfecto.
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * acceleration);
    }

    void MovementDecceleration()
    {
        if(moving == false)
        {
            rb.angularDrag = decceleration;
        } else
        {
            rb.angularDrag = 0.05f;
        }
    }

    void CheckSpeed()
    {
        Debug.Log("Velocidad en x: " + rb.velocity.x);
        Debug.Log("Velocidad en y: " + rb.velocity.y);
        Debug.Log("Velocidad en z: " + rb.velocity.z);
    }

}
