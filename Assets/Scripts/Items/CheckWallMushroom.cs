using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWallMushroom : MonoBehaviour
{
    Mushroom mushroom;
    // Start is called before the first frame update
    void Start()
    {
        mushroom = gameObject.transform.parent.gameObject.GetComponent<Mushroom>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "uBlock" || collision.tag == "Floor" || collision.tag == "Enemy" || collision.tag == "Item")
        {
            mushroom.isGoingRight = !mushroom.isGoingRight;
        }
    }
}
