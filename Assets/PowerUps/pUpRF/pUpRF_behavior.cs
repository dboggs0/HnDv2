using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pUpRF_behavior : MonoBehaviour
{
    Rigidbody2D rb;
    public SpriteRenderer planeModel;
    //Color orange = new Color(191f, 96f, 0x00, 0xFF);
    Color orange = new Color((int) 191f / 255f, (int) 96f / 255f, 0x00, 1.0f);
    Color newColor;
    Color originalColor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject g = GameObject.FindGameObjectWithTag("planeBody");
        planeModel = g.GetComponent<SpriteRenderer>();
        originalColor = planeModel.color;

        

       

    }
    //get colided objects
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        MachineGun mg = hitInfo.gameObject.GetComponent<MachineGun>();
        if (mg != null)
        {
            Stats.ActivePowerUp = "pUpRF";
            GameObject sfxPlayer = GameObject.FindGameObjectWithTag("SFX_Player");
            SFX_Player player = sfxPlayer.GetComponent<SFX_Player>();
            player.Play("powerUp");

            planeModel.color = orange;
            planeModel.color = orange;
            planeModel.color = orange;
            planeModel.color = orange;
            planeModel.color = orange;

            StartCoroutine(doPowerUp(mg));
        }
    }


    private void Update()
    {
        /*
        if (planeModel.color != newColor)
        {
            planeModel.color = newColor;
        }
*/

        
    }

    IEnumerator doPowerUp(MachineGun machineGun)
    {

        newColor = orange;

        Stats.SetActivePowerUp("pUpRF");
        machineGun.setFireRate(5f);
        goHide();
        yield return new WaitForSeconds(10);
        machineGun.setFireRate(2f);
        newColor = Color.white;
        Stats.SetActivePowerUp("");
        Destroy(gameObject);
    }

    void goHide()
    {
        PU_Movement puMove = GetComponent<PU_Movement>();
        puMove.setSpeed(0);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, (float)20);
    }

}
