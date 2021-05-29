using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlock : MonoBehaviour
{
    public bool isHit;
    bool itemSent;
    public string item;
    int amountOfCoins;
    public GameObject redMushroom;
    public GameObject star;
    public GameObject fireFlower;
    public GameObject coin;
    public GameObject greenMushroom;
    public Animator animator;
    public Enemy hasEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit)
        {
            if(item == "Item" && !itemSent && !Player.instance.isBig)
            {
                Vector2 position = new Vector2(transform.position.x, transform.position.y + 1f);
                GameObject spawnMushroom = Instantiate(redMushroom, position, Quaternion.identity);
                spawnMushroom.name = "RedMushroom";
                itemSent = true;
            }
            else if(item == "Item" && !itemSent && Player.instance.isBig)
            {
                Vector2 position = new Vector2(transform.position.x, transform.position.y + 1f);
                GameObject spawnFlower = Instantiate(fireFlower, position, Quaternion.identity);
                spawnFlower.name = "FireFlower";
                itemSent = true;
            }
            else if(item == "Star" && !itemSent)
            {
                Vector2 position = new Vector2(transform.position.x, transform.position.y + 1f);
                GameObject spawnStar = Instantiate(star, position, Quaternion.identity);
                spawnStar.name = "Star";
                itemSent = true;
            }
            else if(item == "Coin" && !itemSent)
            {

            }
            else if(item == "1Up" && !itemSent)
            {

            }
            else if(item == "ManyCois" && !itemSent)
            {

            }

            animator.SetBool("IsHit", isHit);
        }
    }
}
