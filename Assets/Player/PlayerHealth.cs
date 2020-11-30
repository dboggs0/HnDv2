using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    
    public static int maxHP = 200;
    public int HP = maxHP;
    public int defBuff = 1;
    private bool playerDead;

    public GameObject explosionPrefab;
    public GameObject planeSmoke;  //prefab reference
    GameObject smoke;   //instantiated object
    bool isSmoking;



    // Start is called before the first frame update
    void Start()
    {
        playerDead = false;
        isSmoking = false;

    }

    // Update is called once per frame
    void Update()
    {

        if ( !isSmoking && HP < 35 && !playerDead)
        {
            isSmoking = true;
            smoke = Instantiate(planeSmoke, gameObject.transform.position, Quaternion.identity);
            smoke.transform.parent = gameObject.transform;
            smoke.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        if (isSmoking && HP >= 70 )
        {
            isSmoking = false;
            Destroy(smoke);
        }



        if (HP < 1  && !playerDead) {
            Die();
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

    private void Die()
    {
        playerDead = true;

        isSmoking = false;
        Destroy(smoke);

        GameObject explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);

        //Can't destroy the plane without breaking lots of stuff.
        // move it off screen, and disable all input from the user
        // the explosion prefab takes care of switching the the main menu

        PlayerHealth healthScript = gameObject.GetComponent<PlayerHealth>();
        Destroy(healthScript);

        MachineGun mgScript = gameObject.GetComponent<MachineGun>();
        Destroy(mgScript);

        PlayerMovement pmScript = gameObject.GetComponent<PlayerMovement>();
        Destroy(pmScript);

        gameObject.transform.position = new Vector2(1000, 1000);


    }
}
