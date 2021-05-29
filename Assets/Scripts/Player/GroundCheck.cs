using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "Floor" || collision.tag == "Block" || collision.tag == "ItemBlock" || collision.tag == "Pipe"))
        {
            Player.instance.isJumping = false;
            Player.instance.isOnGround = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if((collision.tag == "Floor" || collision.tag == "Block" || collision.tag == "ItemBlock" || collision.tag == "Pipe"))
        {
            Player.instance.isJumping = false;
            Player.instance.isOnGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if((collision.tag == "Floor" || collision.tag == "Block" || collision.tag == "ItemBlock" || collision.tag == "Pipe"))
        {
            Player.instance.isJumping = true;
            Player.instance.isOnGround = false;
        }
    }
}
