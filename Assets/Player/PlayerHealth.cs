using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int HP = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 1) {
            Destroy(gameObject);
        }
    }

    public void damagePlayer(int damage){
        HP -= damage;
    }
}
