using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public int speed = 20;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //destroy bullet if it goes off-screen
        if (transform.position.x > 10){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        Health enemyHealth = hitInfo.gameObject.GetComponent<Health>();
        string tag = hitInfo.gameObject.tag;


        
        if (tag != "powerUp")
        {
            if (enemyHealth != null)
            {
                enemyHealth.takeDamage(25);
            }
            GameObject sfxPlayer = GameObject.FindGameObjectWithTag("SFX_Player");
            SFX_Player player = sfxPlayer.GetComponent<SFX_Player>();
            player.Play("bulletHit");

            Destroy(gameObject);
        }
        
        
    }
}
