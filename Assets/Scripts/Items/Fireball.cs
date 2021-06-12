using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGoingRight;
    public bool isOnGround;
    const float SPEED = 16f;
    const float JUMPFORCE = 900f;
    // Start is called before the first frame update
    void Start()
    {
        isGoingRight = Player.instance.isRight;
        StartCoroutine(LifeTime());
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

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cant kill more than one enemy
        if(collision.tag == "Enemy" || collision.tag == "uBlock")
        {
            Destroy(gameObject);
        }
    }
}
