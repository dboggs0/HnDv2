using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class quitButton : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        //m_YourFirstButton.onClick.AddListener(TaskOnClick);
        btn.onClick.AddListener(QuitGame);

    }


    void QuitGame()
    {
        Application.Quit();

    }
}
