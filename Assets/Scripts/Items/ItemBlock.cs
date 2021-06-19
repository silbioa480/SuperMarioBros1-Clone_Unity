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
                makeItem(redMushroom, "RedMushroom");
            }
            else if(item == "Item" && !itemSent && Player.instance.isBig)
            {
                makeItem(fireFlower, "FireFlower");
            }
            else if(item == "Star" && !itemSent)
            {
                makeItem(star, item);
            }
            else if(item == "Coin" && !itemSent)
            {
                StartCoroutine(CoinLife(makeItem(coin, item)));
                GameManager.points += 100;
                GameManager.coinCount++;
            }
            else if(item == "1Up" && !itemSent)
            {
                makeItem(greenMushroom, item);
            }
            else if(item == "ManyCois" && !itemSent)
            {

            }

            animator.SetBool("IsHit", isHit);
        }
    }

    GameObject makeItem(GameObject _item, string itemName)
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y + 1f);
        GameObject instanceItem = Instantiate(_item, position, Quaternion.identity);
        instanceItem.name = itemName;
        itemSent = true;

        return instanceItem;
    }

    IEnumerator CoinLife(GameObject coin)
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(coin);
    }
}
