using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = -2;
    private Health objectHealth;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 vel = new Vector2(speed,0);
        rb.velocity = vel;

        objectHealth = gameObject.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -10){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        PlayerHealth playerHealth =hitInfo.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null){
            playerHealth.damagePlayer(25);
            objectHealth.Die();
        }
        

    }
}
