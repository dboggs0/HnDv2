using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    private System.DateTime gameOverTimer;
    public int GameOverDelaySeconds;  //set in the inspector

    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverTimer = System.DateTime.Now.AddSeconds(GameOverDelaySeconds);
        Instantiate(gameOverText, new Vector2(0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverTimer < System.DateTime.Now)
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }
}
