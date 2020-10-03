using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = -2;


    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 vel = new Vector2(speed,0);
        rb.velocity = vel;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        PlayerHealth playerHealth =hitInfo.gameObject.GetComponent<PlayerHealth>();
        playerHealth.damagePlayer(25);
        Destroy(gameObject);

    }
}
