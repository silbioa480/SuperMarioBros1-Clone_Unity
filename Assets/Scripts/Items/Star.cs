using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGoingRight = true;
    public bool isOnGround;
    const float SPEED = 6f;
    const float JUMPFORCE = 500f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement;
        if (isGoingRight)
        {
            movement = new Vector2(1, 0);
        }
        else
        {
            movement = new Vector2(-1, 0);
        }

        Vector2 jump = new Vector2(0f, 0f);

        if (isOnGround)
        {
            jump = new Vector2(0f, JUMPFORCE);
            rb.AddForce(jump);
        }

        transform.Translate(movement * SPEED * Time.deltaTime, 0);
    }
}
