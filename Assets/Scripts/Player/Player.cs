using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance = null;

    const float SPEED = 10f;
    const float RUNSPEED = 15f;
    const float JUMPFORCE = 1000f;
    float movementHorizontal = 0f;
    public bool isOnGround = true;
    public bool isJumping = false;
    public bool isBig = false;
    public bool isDead = false;
    public bool isChanging = false;
    public bool hasWon = false;
    public bool isDownPole = false;
    public bool isCrouching = false;
    public bool hasFlower = false;
    public bool changeSize = false;
    bool onPipe;
    Vector2 flagPosition;
    public Rigidbody2D rb;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5)
        {
            isDead = true;
            Debug.Log("Dead");
        }

        movementHorizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetAxisRaw("Vertical") < 0)
        {
            isCrouching = true;
            movementHorizontal = 0f;
        }
        else
        {
            isCrouching = false;
        }

        if(Input.GetKey(KeyCode.Z))
        {
            transform.Translate(new Vector2(movementHorizontal, 0) * RUNSPEED * Time.deltaTime, 0);
        }
        else
        {
            transform.Translate(new Vector2(movementHorizontal, 0) * SPEED * Time.deltaTime, 0);
        }

        if(Input.GetKeyDown(KeyCode.X) && !isJumping)
        {
            rb.AddForce(new Vector2(0f, JUMPFORCE));
            isJumping = true;
            isOnGround = false;
        }
        
        setAnimation();
    }

    void setAnimation()
    {
        animator.SetFloat("Movement", Mathf.Abs(movementHorizontal));
        
        animator.SetBool("IsDead", isDead);
        animator.SetBool("Won", hasWon);
        animator.SetBool("IsDownPole", isDownPole);
        animator.SetBool("IsCrouching", isCrouching);
        animator.SetBool("IsOnGround", isOnGround);
        animator.SetBool("IsBig", isBig);
        animator.SetBool("IsFire", hasFlower);
        animator.SetBool("IsChanging", changeSize);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Flag")
        {
            hasWon = true;
            flagPosition = collision.transform.position;
        }

        if(collision.tag == "Pipe")
        {
            onPipe = true;
        }

        if(collision.tag == "Item")
        {
            if(collision.name == "RedMushroom")
            {
                isBig = true;
                DestroyObject(collision.gameObject);
            }
            else if(collision.name == "FireFlower")
            {
                hasFlower = true;        
                DestroyObject(collision.gameObject);
            }
            else if(collision.name == "Star")
            {
                DestroyObject(collision.gameObject);
            }
            else if(collision.name == "Coin")
            {
                DestroyObject(collision.gameObject);
            }
            else if (collision.name == "GreenMushroom")
            {
                DestroyObject(collision.gameObject);
            }
        }
        if(collision.tag == "Enemy")
        {
            
        }
    }
}
