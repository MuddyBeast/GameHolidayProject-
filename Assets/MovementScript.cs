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
    void Update()
    {
        Debug.Log(currentSpeed);
    }
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = Vector2.right * currentSpeed;
            if (maxSpeed > currentSpeed)
            {
                currentSpeed += movementSpeedIncrease;
                if (currentSpeed > maxSpeed)
                    currentSpeed = maxSpeed;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = Vector2.left * currentSpeed;
            if (maxSpeed > currentSpeed)
            {
                currentSpeed += movementSpeedIncrease;
                if (currentSpeed > maxSpeed)
                    currentSpeed = maxSpeed;
            }
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 5f * Time.deltaTime);
            currentSpeed = startingSpeed;
        }
           
    }
}
