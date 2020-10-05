using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pUpRF_behavior : MonoBehaviour
{
    Rigidbody2D rb;
    void start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //get colided objects
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        MachineGun mg = hitInfo.gameObject.GetComponent<MachineGun>();
        if (mg != null)
        {
            StartCoroutine(doPowerUp(mg));
        }
    }

    IEnumerator doPowerUp(MachineGun machineGun)
    {
        machineGun.setFireRate(5f);
        goHide();
        yield return new WaitForSeconds(10);
        machineGun.setFireRate(2f);
        Destroy(gameObject);
    }

    void goHide()
    {
        PU_Movement puMove = GetComponent<PU_Movement>();
        puMove.setSpeed(0);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, (float)20);
    }

}
