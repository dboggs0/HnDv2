using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Bullet;
    // Start is called before the first frame update
    public float fireRate = 2f;

    float fireDelay = 0f;
    public System.DateTime shotTimer;
    void Start()
    {
        shotTimer = System.DateTime.Now;
        setFireRate(fireRate);
    }

    // Update is called once per frame
    void Update()
    {
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

    public void setFireRate(float newRate)
    {
        CancelInvoke("shoot");
        fireRate = newRate;
        fireDelay = 1 / fireRate;
    }

    void shoot()
    {
        Instantiate(Bullet, firePoint.position, firePoint.rotation);

    }

}
