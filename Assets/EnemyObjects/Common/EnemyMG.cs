using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMG : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletSprite;

    public int fireRate = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 0, fireRate);
    }


    void shoot(){
        if (firePoint.position.x < 7) {
            Instantiate(BulletSprite, firePoint.position, firePoint.rotation);
        }
        
    }
}
