using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool isActivated;
    public bool isAttack;
    public bool isKick;
    public bool isGoingRight;
    public bool isDead;
    public string enemyName;
    const float SPEED = 2f;
    const float SHELLSPEED = 10f;
    public Animator animator;
    public SpriteRenderer sp;
    public bool isHit;
    public Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.instance.transform.position.x + 20 > transform.position.x)
        {
            isActivated = true;
        }

        animator.SetBool("IsDead", isDead);
    }

    void FixedUpdate()
    {
        if(!isDead)
        {
            if(transform.position.y < -5)
            {
                Destroy(gameObject);
            }

            if(enemyName == "PiranhaPlant")
            {

            }
            else
            {
                if(isActivated)
                {
                    if(isGoingRight)
                    {
                        movement = new Vector2(1, 0);
                        sp.flipX = false;
                    }
                    else
                    {
                        movement = new Vector2(-1, 0);
                        sp.flipX = true;
                    }
                }
                
                transform.Translate(movement * SPEED * Time.deltaTime, 0);
            }
        }
        else if(isKick)
        {
            if(isGoingRight)
            {
                movement = new Vector2(1, 0);
            }
            else
            {
                movement = new Vector2(-1, 0);
            }

            transform.Translate(movement * SHELLSPEED * Time.deltaTime, 0);
        }
        else if(enemyName != "Koopa")
        {
            StartCoroutine(killEnemy());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fire")
        {
            isDead = true;
            isGoingRight = !isGoingRight;

            if(enemyName == "Koopa") StartCoroutine(killEnemy());
        }

        if(collision.tag == "Player")
        {
            if((!isDead || isKick) && !isAttack)
            {
                isAttack = true;

                if(Player.instance.hasFlower)
                {
                    Player.instance.hasFlower = false;
                    StartCoroutine(wait(1f));
                    return;
                }

                if(Player.instance.isBig)
                {
                    Player.instance.isBig = false;
                    StartCoroutine(wait(1f));
                    return;
                }

                Player.instance.isDead = true;
                Debug.Log("Player Dead");
            }
        }
    }

    IEnumerator wait(float sec)
    {
        yield return new WaitForSeconds(sec);
        isAttack = false;
    }

    IEnumerator killEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.points += 100;
        Destroy(gameObject);
    }
}
