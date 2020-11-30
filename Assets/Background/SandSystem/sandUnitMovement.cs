using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandUnitMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 speed = new Vector2(-1, 0);
        rb.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
