using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Text score;
    public Text coin;
    public static int points = 0;
    public static int coinCount = 0;
    static int marioLife = 3;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null) instance = this;
        else if(instance != this) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + points;
        coin.text = "Coin: " + coinCount;

        if(coinCount >= 100)
        {
            marioLife++;
            coinCount -= 100;
        }

        if(Player.instance.isDead)
        {
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        marioLife--;
        
        if(marioLife <= 0)
        {
            Debug.Log("GameOver");
        }
        else SceneManager.LoadScene(0);
    }
}
