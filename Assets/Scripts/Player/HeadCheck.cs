using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ItemBlock")
        {

        }

        if(collision.tag == "Block")
        {
            
        }
    }
}
