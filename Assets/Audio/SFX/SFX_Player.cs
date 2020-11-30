using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Player : MonoBehaviour
{
    public AudioClip rockDestroy;
    public AudioClip towerDestroy;
    public AudioClip heliDestroy;
    public AudioClip samDestroy;
    public AudioClip tankDestroy;
    public AudioClip ePlaneDestroy;
    public AudioClip fighterJetDestroy;
    public AudioClip playerBulletHit;
    public AudioClip powerUp;
    public AudioClip pewPew;
    public AudioClip laser;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        if (source == null)
        {
            Debug.LogError("Audio Source missing from SFX_Player.  Check the Inspecter.");
        }

    }

    public void Play(string objectName)
    {
        
        switch (objectName)
        {
            case "rock":
                source.clip = rockDestroy;
                source.Play();
                break;
            case "tower":
                source.clip = towerDestroy;
                source.Play();
                break;
            case "heli":
                source.clip = heliDestroy;
                source.Play();
                break;
            case "tank":
                source.clip = tankDestroy;
                source.Play();
                break;
            case "ePlane":
                source.clip = ePlaneDestroy;
                source.Play();
                break;
            case "fighterJet":
                source.clip = fighterJetDestroy;
                source.Play();
                break;
            case "bulletHit":
                source.clip = playerBulletHit;
                source.Play();
                break;
            case "powerUp":
                source.clip = powerUp;
                source.Play();
                break;
            case "pewPew":
                source.clip = pewPew;
                source.Play();
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
