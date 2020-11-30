using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resumeButton : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        //m_YourFirstButton.onClick.AddListener(TaskOnClick);
        btn.onClick.AddListener(ResumeGame);

    }

    // Update is called once per frame
    void ResumeGame()
    {
        pauseMenu pm = GameObject.Find("HUD").GetComponent<pauseMenu>();
        pm.resumeGame();
    }
}
