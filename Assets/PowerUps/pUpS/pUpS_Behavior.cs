using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pUpS_Behavior : MonoBehaviour
{
    SpriteRenderer planeModel;
    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("plane");
        planeModel = g.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth pHealth = hitInfo.gameObject.GetComponent<PlayerHealth>();
        if (pHealth != null)
        {
            Stats.SetActivePowerUp("pUpS");
            GameObject sfxPlayer = GameObject.FindGameObjectWithTag("SFX_Player");
            SFX_Player player = sfxPlayer.GetComponent<SFX_Player>();
            player.Play("powerUp");

            StartCoroutine(doPowerUp(pHealth));
        }
    }

    IEnumerator doPowerUp(PlayerHealth pHealth)
    {
        planeModel.color = Color.blue;
        pHealth.setDefBuff(3);
        goHide();
        yield return new WaitForSeconds(10);
        pHealth.setDefBuff(1);
        planeModel.color = Color.white;
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
