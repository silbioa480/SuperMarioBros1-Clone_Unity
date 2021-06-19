using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHead : MonoBehaviour
{
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.transform.parent.gameObject.GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            enemy.isDead = true;

            if(enemy.enemyName == "Koopa") enemy.isAttack = true;
        }
    }
}
