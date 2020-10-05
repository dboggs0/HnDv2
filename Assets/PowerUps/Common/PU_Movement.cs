using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = -2;


    
    // Start is called before the first frame update
    void Start()
    {

        setSpeed(speed);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -10){
            Destroy(gameObject);
        }
    }

    public void setSpeed(int newSpeed){
        rb = GetComponent<Rigidbody2D>();
        Vector2 vel = new Vector2(newSpeed,0);
        rb.velocity = vel;
    }

}

