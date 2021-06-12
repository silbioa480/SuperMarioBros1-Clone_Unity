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
    public bool isRight;
    bool onPipe;
    public GameObject head;
    public GameObject feet;
    public GameObject fireball;
    public SpriteRenderer sp;
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
            if(isBig) Crouch(isChanging);
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

        if(Input.GetKeyDown(KeyCode.Z) && hasFlower)
        {
            Vector2 position;
            //shoot in right direction
            if (sp.flipX)
            {
                position = new Vector2(transform.position.x - 1, transform.position.y);
                isRight = false;
            }
            else
            {
                position = new Vector2(transform.position.x + 1, transform.position.y);
                isRight = true;
            }
            Instantiate(fireball, position, Quaternion.identity);
        }

        if(movementHorizontal < 0)
        {
            sp.flipX = true;
        }
        else if(movementHorizontal > 0)
        {
            sp.flipX = false;
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

    void Crouch(bool isCrouch)
    {
        SetHitBox(!isCrouch);
    }

    void SetHitBox(bool bigSize)
    {
        if (bigSize)
        {
            head.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 1f);
            feet.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.1f);
            transform.GetComponent<BoxCollider2D>().size = new Vector2(1f, 2f);
        }
        else
        {
            head.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0.5f);
            feet.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0.35f);
            transform.GetComponent<BoxCollider2D>().size = new Vector2(0.75f, 1f);
        }
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
                SetHitBox(isBig);
                Destroy(collision.gameObject);
            }
            else if(collision.name == "FireFlower")
            {
                hasFlower = true;        
                Destroy(collision.gameObject);
            }
            else if(collision.name == "Star")
            {
                Destroy(collision.gameObject);
            }
            else if(collision.name == "Coin")
            {
                Destroy(collision.gameObject);
            }
            else if (collision.name == "GreenMushroom")
            {
                Destroy(collision.gameObject);
            }
        }
        if(collision.tag == "Enemy")
        {
            
        }
    }
}
