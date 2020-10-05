using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public static int maxHP = 100;
    public int HP = maxHP;
    public int defBuff = 1;
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
        HP -= damage / defBuff;
    }

        public void healPlayer(int damage){
        HP += damage;
        if (HP > maxHP) {
            HP = maxHP;
        }
    }

    public void setDefBuff(int buff){
        defBuff = buff;
    }
}
