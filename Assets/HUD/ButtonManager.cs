using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


public class ButtonManager : MonoBehaviour
{
    float verticalInput;
    GameObject btnPlay;
    GameObject btnQuit;
    EventSystem eventSys;

    // Start is called before the first frame update
    void Start()
    {
        eventSys = EventSystem.current;

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0) {
            btnPlay = GameObject.Find("btnPlayGame");
            eventSys.SetSelectedGameObject(btnPlay);
        }
        else if (verticalInput < 0)
        {
            btnQuit = GameObject.Find("btnQuitGame");
            eventSys.SetSelectedGameObject(btnQuit);
        }
        else
        {
            eventSys.SetSelectedGameObject(null);
        }

    }
}
