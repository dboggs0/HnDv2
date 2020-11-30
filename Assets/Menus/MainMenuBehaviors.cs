using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBehaviors : MonoBehaviour
{
    bool isPaused;
    public GameObject pauseMenu;

    public void Start()
    {
        isPaused = false;

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = !isPaused;
                ResumeGame();
            }
            else
            {
                isPaused = !isPaused;
                PauseGame();
            }
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1");
        //Debug.Log("got here");
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }

    public void PauseGame()
    {

        Time.timeScale = 0;
    }

    public void ResumeGame()
    {

        Time.timeScale = 1;
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main_Menu");
        //SceneManager.UnloadSceneAsync("Level_1");
    }
}
