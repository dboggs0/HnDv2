using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    int speed = -1;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 velocity = new Vector2(speed, 0);
        rb.velocity = velocity;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.name == "player_PF")
        {
            Debug.Log("finish line crossed");
            SceneManager.LoadScene(0);
        }


    }
}
