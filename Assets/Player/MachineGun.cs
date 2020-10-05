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

    float fireDelay = 0f;
    public System.DateTime shotTimer;
    bool lasering = false;
    void Start()
    {
        activeWeapon = "bullet";
        shotTimer = System.DateTime.Now;
        setFireRate(fireRate);


    }

    // Update is called once per frame
    void Update()
    {


        if (activeWeapon == "laser")
        {
            if (!lasering)
            {
                lasering = true;
                shoot();
                //shoot for 5 seconds --- taken care of by laser_behavior.cs
            }
        }
        else
        {

            lasering = false;
            if (Input.GetButton("Fire1"))
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
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
        if (activeWeapon == "laser")
        {
            Instantiate(laser, firePoint.position, firePoint.rotation);
        }

    }


}
