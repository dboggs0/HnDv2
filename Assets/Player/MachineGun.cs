using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public GameObject laser;
    public string activeWeapon;
    public float fireRate = 2f;
    public GameObject planeBody;
    Color defaultBodyColor;

    float fireDelay = 0f;
    public System.DateTime shotTimer;
    bool lasering = false;
    void Start()
    {
        activeWeapon = "bullet";
        shotTimer = System.DateTime.Now;
        setFireRate(fireRate);
        defaultBodyColor = planeBody.GetComponent<SpriteRenderer>().color;

    }

    // Update is called once per frame
    void Update()
    {

        if (Stats.GamePaused) {
            return;
        }
        if (activeWeapon == "laser")
        {
            if (!lasering)
            {
                lasering = true;
                planeBody.GetComponent<SpriteRenderer>().color = Color.white;
                shoot();
                //shoot for 5 seconds --- taken care of by laser_behavior.cs
            }
        }
        else
        {

            lasering = false;
            planeBody.GetComponent<SpriteRenderer>().color = defaultBodyColor;
            if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space))
            {
                if (System.DateTime.Now > shotTimer)
                {
                    shotTimer = System.DateTime.Now;
                    shotTimer = shotTimer.AddSeconds(fireDelay);
                    shoot();
                }
            }
        }


    }

    public void setFireRate(float newRate)
    {
        fireRate = newRate;
        fireDelay = 1 / fireRate;
    }

    void shoot()
    {
        if (activeWeapon == "bullet")
        {
            GameObject sfxPlayer = GameObject.FindGameObjectWithTag("SFX_Player");
            SFX_Player player = sfxPlayer.GetComponent<SFX_Player>();
            player.Play("pewPew");
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
        if (activeWeapon == "laser")
        {
            Instantiate(laser, firePoint.position, firePoint.rotation);
        }

    }


}
