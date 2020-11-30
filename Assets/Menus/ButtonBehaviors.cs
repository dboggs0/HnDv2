using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using UnityEngine.UIElements;


public class ButtonBehaviors : MonoBehaviour
{
    pauseMenu pauseMenuScript;


    public void Start()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        pauseMenuScript.resumeGame();
    }


    public void Quit()
    {
        Application.Quit();
    }
}
