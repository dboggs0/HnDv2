using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockSound : MonoBehaviour
{
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        GameObject soundPlayer = GameObject.Find("SFX_Player");
        if (soundPlayer != null)
        {
            AudioSource source = soundPlayer.GetComponent<AudioSource>();
            if (source != null)
            {
                source.clip = audioClip;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
