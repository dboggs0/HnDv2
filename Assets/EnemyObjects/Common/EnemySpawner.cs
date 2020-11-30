using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public delegate void NewWave(int waveNumber);  //defines the delegate
    public static NewWave newWave;            //delegate instance

    public float[] spawnpoint;
    public GameObject rock;
    public GameObject tower;
    public GameObject heli;
    public GameObject ePlane;
    public GameObject fighterJet;
    public GameObject SAM;
    public GameObject tank;

    public int unitX_OffsetMin;
    public int unitX_OffsetMax;

    private int waveNumber;

    private int spawnLevel;
    private GameObject[] units;
    private int numberOfActiveUnits;

    private Vector2 screenBounds;
    private List<GameObject> availableEnemyUnits;

    private bool isSpawning;

    public GameObject GameWonMessage;


    // Start is called before the first frame update
    void Start()
    {
        isSpawning = true;
        availableEnemyUnits = new List<GameObject>();
        spawnLevel = 0;
        Vector2 originalScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenBounds = new Vector2(0, 0);
        screenBounds.x = originalScreenBounds.x; //right side of screen
        screenBounds.y = originalScreenBounds.y; //top of screen

        waveNumber = 0;

        // I don't think this is used anywhere
        spawnpoint = new float[2];
        spawnpoint[0] = 0;
        spawnpoint[1] = 0;


    }

    // Update is called once per frame
    void Update()
    {

        if (!Stats.GamePaused && countActiveUnits() ==0 && spawnLevel == 20)
        {
            isSpawning = false;
            Win();
        }

        if (!Stats.GamePaused && countActiveUnits() == 0 && isSpawning)
        {
            spawnLevel += 1;
            newWave?.Invoke(spawnLevel);
            generateUnits();
            sendUnits();
        }



    }

    int countActiveUnits()
    {
        int count = 0;
        string[] tags = {
            "ePlane",
            "fighterJet",
            "heli",
            "rock",
            "sam",
            "tank",
            "tower"
        };

        for (int i=0; i < tags.Length; i++)
        {
            count = count + GameObject.FindGameObjectsWithTag(tags[i]).Length;
        }

        return count;
    }

    void generateUnits()
    {
        waveNumber++;

        switch (spawnLevel)
        {
            case 1:
                //spawn level 1:    rocks and towers
                if (!availableEnemyUnits.Contains(rock))
                {
                    availableEnemyUnits.Add(rock);
                    availableEnemyUnits.Add(tower);
                    
                }
                break;
            case 3:
                //spawn level 2:    add helis
                if (!availableEnemyUnits.Contains(heli))
                {
                    availableEnemyUnits.Add(heli);
                    
                }
                break;
            case 5:
                //spawn level 3:    add ePlanes
                if (!availableEnemyUnits.Contains(ePlane))
                {
                    availableEnemyUnits.Add(ePlane);
                    
                }
                break;
            case 7:
                //spawn level 4:    add SAMs
                if (!availableEnemyUnits.Contains(SAM))
                {
                    availableEnemyUnits.Add(SAM);
                    
                }
                break;
            case 9:
                //spawn level 5:    add tanks
                if (!availableEnemyUnits.Contains(tank))
                    
                {
                    availableEnemyUnits.Add(tank);
                }
                break;
            case 11:
                //spawn level 6:    add fighter jets
                if (!availableEnemyUnits.Contains(fighterJet))
                {
                    availableEnemyUnits.Add(fighterJet);
                    
                }
                break;
            default:
                break;
        }

        int numUnits = availableEnemyUnits.Count + (int) (waveNumber / 2);
        units = new GameObject[numUnits ];

        System.Random rand = new System.Random();

        for (int i=0; i< numUnits; i++)
        {
            units[i] = availableEnemyUnits[rand.Next(0, availableEnemyUnits.Count)];
        }

        shuffleEnemyUnits();
    }

    void shuffleEnemyUnits()
    {
        List<GameObject> slowUnits = new List<GameObject>();
       // slowUnits.Add(rock);
       // slowUnits.Add(tower);
        slowUnits.Add(tank);

        List<GameObject> newUnits = new List<GameObject>();


        for (int i = 0; i < units.Length; i++)
        {
            if (slowUnits.Contains(units[i]))
            {
                newUnits.Add(units[i]);
            }
        }

        
        for (int i = 0; i < units.Length; i++)
        {

            if (!slowUnits.Contains(units[i]))
            {
                newUnits.Add(units[i]);
            }
        }

        for (int i = 0; i < units.Length; i++)
        {
            units[i] = newUnits[i];
        }
    }

    void sendUnits()
    {
        System.Random rand = new System.Random();
        rand.NextDouble();  // probably not needed
        double randY_offset;


        Vector2 spawnPosition = new Vector2(screenBounds.x, screenBounds.y);
        int offset = 1;
        for (int i=0; i < units.Length; i++)
        {
            
            randY_offset = rand.Next((int)-screenBounds.y * 1000, (int) screenBounds.y * 1000);
            randY_offset = randY_offset / 1100;  // keeps enemy units from spawning half off of the screen
            spawnPosition.y = (float)randY_offset;
            //spawnPosition.x = spawnPosition.x + (spawnPosition.x * 0.1f) + (i * offset);
            spawnPosition.x = spawnPosition.x + (spawnPosition.x * 0.1f);
            Instantiate(units[i], spawnPosition, Quaternion.identity);
        }
    }

    public void Win()
    {
        //display winning message
        //let the winning message take care of returning to the title screen
        // and disabling all spawning scripts
        Instantiate(GameWonMessage, new Vector3(0, 0, 0), Quaternion.identity);
    }


}
