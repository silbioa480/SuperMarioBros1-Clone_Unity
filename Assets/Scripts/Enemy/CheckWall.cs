using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.transform.parent.gameObject.GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && enemy.isKick)
        {
            collision.GetComponent<Enemy>().isDead = true;
        }
        
        if (collision.tag == "uBlock" || collision.tag == "Floor" || collision.tag == "Enemy" || collision.tag == "Item")
        {
            enemy.isGoingRight = !enemy.isGoingRight;
        }

        if(collision.tag == "Player" && enemy.enemyName == "Koopa" && enemy.isDead && !enemy.isKick)
        {
            enemy.isGoingRight = !enemy.isGoingRight;
            enemy.isKick = true;
            StartCoroutine(waitAttack());
        }
    }

    IEnumerator waitAttack()
    {
        yield return new WaitForSeconds(1f);
        enemy.isAttack = false;
    }
}
