using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWallStar : MonoBehaviour
{
    Star star;
    // Start is called before the first frame update
    void Start()
    {
        star = gameObject.transform.parent.gameObject.GetComponent<Star>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "uBlock" || collision.tag == "Floor" || collision.tag == "Enemy" || collision.tag == "Item")
        {
            star.isGoingRight = !star.isGoingRight;
        }
    }
}
