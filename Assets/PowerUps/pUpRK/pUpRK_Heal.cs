using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pUpRK_Heal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



        void OnTriggerEnter2D(Collider2D hitInfo){
            
            PlayerHealth playerHealth = hitInfo.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null){
                playerHealth.healPlayer(66);

                GameObject sfxPlayer = GameObject.FindGameObjectWithTag("SFX_Player");
                SFX_Player player = sfxPlayer.GetComponent<SFX_Player>();
                player.Play("powerUp");

                Destroy(gameObject);
            }
        
        
        
    }
}
