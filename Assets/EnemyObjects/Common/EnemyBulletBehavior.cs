using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
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
        if (transform.position.x < -10){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        PlayerHealth playerHealth = hitInfo.gameObject.GetComponent<PlayerHealth>();
        //BUG throws exception when it hits another bullet
        if (playerHealth != null){
            playerHealth.damagePlayer(25);
        }
        
        Destroy(gameObject);
        
    }
}
