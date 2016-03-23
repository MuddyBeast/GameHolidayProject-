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
		Vertical ();
		Horizontal ();



		if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 5f * Time.deltaTime);
            currentSpeed = startingSpeed;
        }

           
    }

	void Horizontal()
	{
		if (Input.GetAxisRaw ("Horizontal") > 0) 
		{
			rb.velocity = Vector2.right * currentSpeed;
			if (maxSpeed > currentSpeed) 
			{
				currentSpeed += movementSpeedIncrease;
				if (currentSpeed > maxSpeed)
					currentSpeed = maxSpeed;
			}
		} 
		else if (Input.GetAxisRaw ("Horizontal") < 0) 
		{
			rb.velocity = Vector2.left * currentSpeed;
			if (maxSpeed > currentSpeed) 
			{
				currentSpeed += movementSpeedIncrease;
				if (currentSpeed > maxSpeed)
					currentSpeed = maxSpeed;
			}
		}
	}


	void Vertical()
	{
		if (Input.GetAxisRaw ("Vertical") > 0) 
		{
			rb.velocity = Vector2.up * currentSpeed;
			if (maxSpeed > currentSpeed) 
			{
				currentSpeed += movementSpeedIncrease;
				if (currentSpeed > maxSpeed)
					currentSpeed = maxSpeed;
			}
		} else if (Input.GetAxisRaw ("Vertical") < 0) 
		{
			rb.velocity = Vector2.down * currentSpeed;
			if (maxSpeed > currentSpeed) 
			{
				currentSpeed += movementSpeedIncrease;
				if (currentSpeed > maxSpeed)
					currentSpeed = maxSpeed;
			}
		}
	}
}
