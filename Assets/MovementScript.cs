using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    Rigidbody2D rb;

    public float startingSpeed;
    float currentSpeed;
    public float movementSpeedIncrease;
    public float maxSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = startingSpeed;
    }


    void FixedUpdate()
    {
        //Debug.Log(currentSpeed);
        //if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        //{
        //    rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 5f * Time.deltaTime);
        //    currentSpeed = startingSpeed;
        //}
        Movement();

    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(h * currentSpeed, v * currentSpeed);

        if (maxSpeed > currentSpeed)
        {
            currentSpeed += movementSpeedIncrease;
            if (currentSpeed > maxSpeed)
                currentSpeed = maxSpeed;
        }
        if (h == 0 && v == 0)
            currentSpeed = startingSpeed;        
        


        //if (Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    transform.Translate(Vector2.right * currentSpeed);
        //    if (maxSpeed > currentSpeed)
        //    {
        //        currentSpeed += movementSpeedIncrease * Time.deltaTime;
        //        if (currentSpeed > maxSpeed)
        //            currentSpeed = maxSpeed;
        //    }
        //}
        //else if (Input.GetAxisRaw("Horizontal") < 0)
        //{
        //    transform.Translate(Vector2.left * currentSpeed);
        //    if (maxSpeed > currentSpeed)
        //    {
        //        currentSpeed += movementSpeedIncrease * Time.deltaTime;
        //        if (currentSpeed > maxSpeed)
        //            currentSpeed = maxSpeed;
        //    }
        //}
        //else
        //{
        //    rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 5f * Time.deltaTime);
        //    currentSpeed = startingSpeed;
        //}
    }
}
