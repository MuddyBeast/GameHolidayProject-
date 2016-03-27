using UnityEngine;
using System.Collections;

public class DistanceToPlayer : MonoBehaviour
{
    GameObject player;
    float distance;
    Vector2 PlatformUpPosition;
    Vector2 platformDownPosition;
    SpriteRenderer sprite;
    bool platformDown = false;
    public float distanceForPlatformToAppear = 4.3f;
    public float delayForPlatform = 3f;


    // Use this for initialization
    void Start()
    {
        PlatformUpPosition = new Vector2(transform.position.x, transform.position.y + 5f);
        platformDownPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(platformDownPosition, player.transform.position);
           
    }


    void FixedUpdate()
    {
        if (distance < distanceForPlatformToAppear)
            TakeDownPlatform();
        else
            TakeUpPlatform();
    }

    void TakeDownPlatform()
    {
        transform.position = Vector2.Lerp(transform.position, platformDownPosition, delayForPlatform * Time.deltaTime);
        if(PlatformUpPosition.y > transform.position.y)
        {
            sprite.enabled = true;
        }
    }

    void TakeUpPlatform()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, Camera.main.pixelHeight/2), delayForPlatform * Time.deltaTime);
        if(transform.position.y > Camera.main.pixelHeight/2 - 0.1f)
        {
            sprite.enabled = false;
        }
    }
}