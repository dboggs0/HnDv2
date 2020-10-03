using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 forward;
    public Vector2 backward;
    public Vector2 up;
    public Vector2 down;
    public int speed;
    public float horizontalInput;
    public float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 200;
        forward = new Vector2(speed,0);
        backward = new Vector2(-speed,0);
        up = new Vector2(0,speed);
        down = new Vector2(0,-speed);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector2 vec = (new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime );
        rb.velocity = vec;

        if (transform.position.x < -8.3){
            transform.position = new Vector2((float) -8.3, transform.position.y);
        }
        if (transform.position.x > -6.4){
            transform.position = new Vector2((float) -6.4, transform.position.y);
        }
        if (transform.position.y > 4.3){
            transform.position = new Vector2(transform.position.x, (float) 4.3);
        }
        if (transform.position.y < -4.3){
            transform.position = new Vector2(transform.position.x, (float) -4.3);
        }

    }
}