using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    System.DateTime mainMenuTimer;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuTimer = System.DateTime.Now.AddSeconds(7);
        //disable spawning scripts
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        Destroy(enemySpawner);

        GameObject pUpSpawner = GameObject.Find("PowerUpSpawner");
        Destroy(pUpSpawner);

        //return to the main menu after a delay
    }

    // Update is called once per frame
    void Update()
    {
        if (mainMenuTimer < System.DateTime.Now)
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }
}
