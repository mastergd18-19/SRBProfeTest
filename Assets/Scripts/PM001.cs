using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM001 : MonoBehaviour
{
    
    #region Lateral
    public float speed;
    public float acceleration;
    public float deceleration;
    Rigidbody2D rb;
    float horizontal;
    Vector2 vel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento con aceleración y desaceleración
        MovementAcc();
        rb.velocity = vel;
    }

    void MovementAcc()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            vel.x = acceleration * horizontal;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            vel.x = deceleration * horizontal;
        }

        vel.x = Mathf.Clamp(vel.x, -speed, speed);
    }

    void Movement()
    {

        if (Input.GetKey(KeyCode.D))
        { // Hacia la derecha
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {// Hacia la izquierda
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        { // Si no se mueve
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    #endregion
    

    /*
    #region Lateral 2

    public float walkSpeed;
    public float sprintSpeed;
    public int iterations;

    private Vector3 currentSpeed;
    private Animator anim;
    private float actualSpeed;

    List<float> xValues = new List<float>();


    private void Start()
    {
        actualSpeed = walkSpeed;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        xValues.Add(Input.GetAxisRaw("Horizontal") * actualSpeed);

        if (xValues.Count > iterations)
        {
            xValues.Remove(xValues[0]);
        }

        float mediaX = 0;

        for (int i = 0; i < xValues.Count; i++)
        {
            mediaX += xValues[i];
        }
        mediaX /= xValues.Count;

        if (Input.GetButton("Sprint"))
        {
            actualSpeed = sprintSpeed;
        }
        else
            actualSpeed = walkSpeed;
    }
    #endregion
    */

    #region
    #endregion
}