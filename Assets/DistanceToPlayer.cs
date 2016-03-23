using UnityEngine;
using System.Collections;

public class DistanceToPlayer : MonoBehaviour 
{
	GameObject player;
	float distance;
	Vector2 PlatformUpPosition;
	Vector2 platformDownPosition;
	bool platformDown = false;
	public float distanceForPlatformToAppear = 4.3f;
	public float delayForPlatform = 3f;


	// Use this for initialization
	void Start () 
	{
		PlatformUpPosition = transform.position;
		platformDownPosition = new Vector2(transform.position.x, transform.position.y - 11f);

		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		distance = Vector2.Distance(platformDownPosition, player.transform.position);

	}


	void FixedUpdate()
	{
		if (distance < 4.3f)
			TakeDownPlatform ();
		else
			TakeUpPlatform ();
	}

	void TakeDownPlatform()
	{
		transform.position = Vector2.Lerp (transform.position, platformDownPosition, delayForPlatform * Time.deltaTime);
	}

	void TakeUpPlatform()
	{
		transform.position = Vector2.Lerp (transform.position, PlatformUpPosition, delayForPlatform * Time.deltaTime);
	}
}