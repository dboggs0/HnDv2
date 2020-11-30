using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_behavior : MonoBehaviour
{
    public int speed = 20;
    public Rigidbody2D rb;
    GameObject gun;
    double pUpTimer;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Player is now lasering");
        Stats.SetActivePowerUp("pUpL");
        pUpTimer = 7f;
        gun = GameObject.FindWithTag("playerGun");
    }

    // Update is called once per frame
    void Update()
    {
        Transform theSpot = gun.GetComponent<Transform>();

        transform.position = new Vector2(theSpot.position.x, theSpot.position.y);

        pUpTimer -= Time.deltaTime;

        if (pUpTimer <= 0)
        {
            Destroy(gameObject);
            ///MachineGun.cs activeWeapon = "bullet";
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                MachineGun gunScript = player.GetComponent<MachineGun>();
                gunScript.activeWeapon = "bullet";
                Stats.SetActivePowerUp("");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Health enemyHealth = hitInfo.gameObject.GetComponent<Health>();

        if (enemyHealth != null)
        {
            enemyHealth.Die();
        }
    }

}
