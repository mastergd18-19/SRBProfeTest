using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region VARIABLES
    public float speed;
    public float acceleration;
    public float deceleration;
    float lateral;
    float forward;
    Rigidbody rb;
    Vector3 vel;
    #endregion

    #region START & UPDATE
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = vel;
        Acceleration();
        Movement();
    }
    #endregion

    #region MOVEMENT & ACCELERATION
    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }
    }

    void Acceleration()
    {
        if(forward !=0 && lateral != 0)
        {
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, 0, 5);
        }


        /*
        forward = Input.GetAxis("Vertical");
        lateral = Input.GetAxis("Horizontal");

        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            vel.x = acceleration * lateral * Time.deltaTime;
        }

        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            vel.x = deceleration * lateral * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            vel.z = acceleration * forward * Time.deltaTime;
        }

        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            vel.z = deceleration * forward * Time.deltaTime;
        }
        */


    }
    #endregion
}
