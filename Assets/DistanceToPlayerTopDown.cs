using UnityEngine;
using System.Collections;

public class DistanceToPlayerTopDown : MonoBehaviour
{
    GameObject player;
    float distance;
    SpriteRenderer sprite;
    public float distanceForPlatformToAppear = 5f;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

    }


    void FixedUpdate()
    {
        if (distance < distanceForPlatformToAppear)
            ShowPlatform();
        else
            HidePlatform();
    }

    void ShowPlatform()
    {
        sprite.enabled = true;
    }

    void HidePlatform()
    {
        sprite.enabled = false;
    }
}