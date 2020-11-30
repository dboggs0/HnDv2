using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject pauseButtons;
    private GameObject pauseButtonsRef;




    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Update() is not called when timeScale is 0.  Need to set timeScale elsewhere
        //if (Input.GetKeyDown(KeyCode.Escape) or Gamepad.current[GamepadButton.startButton]){
        if (Input.GetButtonDown("Cancel")){
            if (!isPaused)
            {
                pauseGame();
            }
            else
            {
                resumeGame();
            }
        }


    }

    public void pauseGame()
    {
        isPaused = true;

        pauseButtonsRef = Instantiate(pauseButtons, transform, true);
        GameObject btnContainer = GameObject.Find("PauseButtons");
        pauseButtonsRef.transform.SetParent(btnContainer.transform);

        Time.timeScale = 0;
        Stats.PauseGame();
    }

    public void resumeGame()
    {

        Destroy(pauseButtonsRef);
        isPaused = false;
        Time.timeScale = 1;
        Stats.UnpauseGame();
    }
}
