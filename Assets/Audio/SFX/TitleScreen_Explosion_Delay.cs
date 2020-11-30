using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen_Explosion_Delay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource explosion = gameObject.GetComponent<AudioSource>();
        explosion.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
