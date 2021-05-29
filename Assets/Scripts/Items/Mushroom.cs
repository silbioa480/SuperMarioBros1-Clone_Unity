using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public bool isGoingRight = true;
    const float SPEED = 2f;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGoingRight)
        {
            movement = new Vector2(1, 0);
        }
        else
        {
            movement = new Vector2(-1, 0);
        }

        transform.Translate(movement * SPEED * Time.deltaTime, 0);
    }
}
