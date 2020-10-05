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
        Debug.Log(hitInfo.gameObject.name);
        MachineGun mg = hitInfo.gameObject.GetComponent<MachineGun>();
        if (mg != null)
        {
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
