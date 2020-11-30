using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pUpL_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        MachineGun mg = hitInfo.gameObject.GetComponent<MachineGun>();
        if (mg != null)
        {
            Stats.SetActivePowerUp("pUpL");
            GameObject sfxPlayer = GameObject.FindGameObjectWithTag("SFX_Player");
            SFX_Player player = sfxPlayer.GetComponent<SFX_Player>();
            player.Play("powerUp");

            mg.activeWeapon = "laser";
            goHide();
        }
    }
        void goHide()
    {
        PU_Movement puMove = GetComponent<PU_Movement>();
        puMove.setSpeed(0);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, (float)20);
    }
}
