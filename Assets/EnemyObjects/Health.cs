using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 1 ){
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage){
        HP = HP - damage;
    }
}
