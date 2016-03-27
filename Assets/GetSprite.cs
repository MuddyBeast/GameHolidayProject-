using UnityEngine;
using System.Collections;

public class GetSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public DistanceToPlayerTopDown distanceToPlayer;
    public bool isInvis = true;

    float posX = 0;
    float posY = 0;

    public float swapY = 25;
    public float moveInX = 5;

    // Use this for initialization
    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("Gräs");

        for (int i = 0; i < sprites.Length; i++)
        {
            GameObject newGameObject = new GameObject("Background n." + i);
            newGameObject.transform.position = new Vector2(posX, posY);
            newGameObject.AddComponent<SpriteRenderer>().sprite = sprites[i];
            if (isInvis)
                newGameObject.AddComponent<DistanceToPlayerTopDown>();
            posX += moveInX;
            if (posX > swapY)
            {
                posX = 0;
                posY -= moveInX;
            }

        }


    }
}
