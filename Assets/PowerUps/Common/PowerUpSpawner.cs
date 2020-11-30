using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using System;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject pUpL;
    public GameObject pUpRF;
    public GameObject pUpRK;
    public GameObject pUpS;

    public int powerUpDelay; //seconds
    private double pu_timer;

    private GameObject[] powerUps;


    // Start is called before the first frame update
    void Start()
    {
        //pu_timer = System.DateTime.Now;
        //pu_timer = pu_timer.AddSeconds(powerUpDelay);
        pu_timer = powerUpDelay;


        powerUps = new GameObject[4];
        powerUps[0] = pUpL;
        powerUps[1] = pUpRF;
        powerUps[2] = pUpRK;
        powerUps[3] = pUpS;

    }

    // Update is called once per frame
    void Update()
    {

        pu_timer -=  Time.deltaTime;
        // if (pu_timer.Compare(System.DateTime.Now))
        if (pu_timer <= 0)
        {
            pu_timer = powerUpDelay;
            spawnPowerUp();
        }


    }

    void spawnPowerUp()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //Vector2 spawnPosition = new Vector2(screenBounds.x, screenBounds.y);
        screenBounds.x = screenBounds.x + 1;

        int newY = UnityEngine.Random.Range((int) -screenBounds.y + 1, (int) screenBounds.y);
        screenBounds.y = newY;

        int index = UnityEngine.Random.Range(0, powerUps.Length);
        Instantiate(powerUps[index], screenBounds, Quaternion.identity);

    }
}
