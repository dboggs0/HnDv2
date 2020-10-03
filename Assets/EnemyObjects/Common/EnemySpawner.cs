using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public bool stopSpawning = false;
    public float spawnStartTime;
    public float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpwanObject", spawnStartTime, spawnDelay);
    }

    public void SpwanObject(){
        System.Random rand = new System.Random((int) DateTime.Now.Ticks & 0x0000FFFF);
        int yInt = rand.Next(-43, 43);
        float yPos = yInt / 10;

        Vector2 position = new Vector2(6, yPos);
        Instantiate(spawnObject,position, transform.rotation);
        if (stopSpawning){
            CancelInvoke("SpwanObject");
        }
    }
}
