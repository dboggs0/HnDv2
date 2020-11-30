using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpStatus : MonoBehaviour
{
    public Sprite imgRepairKit;
    public Sprite imgRapidFire;
    public Sprite imgLaser;
    public Sprite imgShield;
    public Sprite imgClear;

    // Start is called before the first frame update
    void Start()
    {
        Stats.activePowerUpChanged += setPowerUpIcon;
        Stats.SetActivePowerUp("");
    }

    private void OnDestroy()
    {
        Stats.activePowerUpChanged -= setPowerUpIcon;
    }

    public void setPowerUpIcon()
    {
        

        switch (Stats.ActivePowerUp) {

            case "pUpL":
                
                gameObject.GetComponent<Image>().sprite = imgLaser;
                break;
            case "pUpRF":
                gameObject.GetComponent<Image>().sprite = imgRapidFire;
                break;
            case "pUpS":
                gameObject.GetComponent<Image>().sprite = imgShield;
                break;
            default:
                gameObject.GetComponent<Image>().sprite = imgClear;
                break;
        }
        

    }


}
