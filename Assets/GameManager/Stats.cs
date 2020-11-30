using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static string ActivePowerUp;
    public static int NumberOfActiveEnimies;
    public static bool GamePaused;
    public delegate void ActivePowerUpChanged();  //defines the delegate
    public static ActivePowerUpChanged activePowerUpChanged; //delegate instance


    // Start is called before the first frame update
    void Start()
    {
        ActivePowerUp = "";
        NumberOfActiveEnimies = 0;
        UnpauseGame();


    }

    public static void SetActivePowerUp(string pUP)
    {
        
        ActivePowerUp = pUP;
        activePowerUpChanged?.Invoke();
    }

    public static void PauseGame()
    {
        GamePaused = true;
    }

    public static void UnpauseGame()
    {
        GamePaused = false;
    }

}
