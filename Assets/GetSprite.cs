using UnityEngine;
using System.Collections;

public class GetSprite : MonoBehaviour
{
    public GameObject backgroundBlock;
    public Sprite[] sprites;
    public DistanceToPlayerTopDown distanceToPlayer;
    public bool isInvis = true;

    float posX = 0;
    float posY = 0;

    
    public float swapY = 24;
    float swapYCalculated;
 
    float moveInX = 5;

    // Use this for initialization
    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("Gräs");
        moveInX = sprites[0].bounds.size.x;
        swapYCalculated = swapY * moveInX;

        for (int i = 0; i < sprites.Length; i++)
        {
            GameObject newGameObject = Instantiate(backgroundBlock, new Vector2(posX, posY), Quaternion.identity) as GameObject;
            newGameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
            newGameObject.transform.parent = transform;
            //GameObject newGameObject = new GameObject("Background n." + i);
            //newGameObject.transform.position = new Vector2(posX, posY);
            //newGameObject.AddComponent<SpriteRenderer>().sprite = sprites[i];
            if (isInvis == false)
            newGameObject.GetComponent<DistanceToPlayerTopDown>().enabled = false;

            posX += moveInX;
            if (posX > swapYCalculated)
            {
                posX = 0;
                posY -= moveInX;
            }

        }


    }
}
