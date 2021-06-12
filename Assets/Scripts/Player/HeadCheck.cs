using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ItemBlock")
        {
            collision.GetComponent<ItemBlock>().isHit = true;
        }

        if(collision.tag == "Block")
        {
            if(Player.instance.isBig)
            {
                StartCoroutine(breakBlock(collision));
            }
        }
    }

    IEnumerator breakBlock(Collider2D collision)
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(collision.gameObject);
    }
}
