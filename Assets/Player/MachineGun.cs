using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletSprite;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            shoot();
        }
        
    }

    void shoot(){
        Instantiate(BulletSprite, firePoint.position, firePoint.rotation);
        
    }
}
