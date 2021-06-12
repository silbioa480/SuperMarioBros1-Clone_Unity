using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckFireball : MonoBehaviour
{
    Fireball fireball;
    // Start is called before the first frame update
    void Start()
    {
        fireball = gameObject.transform.parent.gameObject.GetComponent<Fireball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor" || collision.tag == "Block" || collision.tag == "ItemBlock")
        {
            fireball.isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor" || collision.tag == "Block" || collision.tag == "ItemBlock")
        {
            fireball.isOnGround = false;
        }
    }
}
