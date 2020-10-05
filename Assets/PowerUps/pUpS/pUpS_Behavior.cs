using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pUpS_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth pHealth = hitInfo.gameObject.GetComponent<PlayerHealth>();
        if (pHealth != null)
        {
            StartCoroutine(doPowerUp(pHealth));
        }
    }

    IEnumerator doPowerUp(PlayerHealth pHealth)
    {
        pHealth.setDefBuff(3);
        goHide();
        yield return new WaitForSeconds(10);
        pHealth.setDefBuff(1);
        Destroy(gameObject);
        
    }

    void goHide()
    {
        PU_Movement puMove = GetComponent<PU_Movement>();
        puMove.setSpeed(0);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, (float)20);
    }
}
