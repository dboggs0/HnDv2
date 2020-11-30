using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Manager : MonoBehaviour
{
    public Slider healthSlider;
    public GameObject player;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        
        healthSlider.value = player.GetComponent<PlayerHealth>().HP;
        healthSlider.maxValue = PlayerHealth.maxHP;

    }

    // Update is called once per frame
    void Update()
    {
        int playerOjbects = GameObject.FindObjectsOfType<PlayerHealth>().Length;

        if (playerOjbects > 0)
        {
            healthSlider.value = player.GetComponent<PlayerHealth>().HP;
        }
        
    }
}
