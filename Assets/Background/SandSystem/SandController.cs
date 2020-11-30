using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandController : MonoBehaviour
{
    public GameObject sandQuad;
    private GameObject[] tileQueue = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        tileQueue[0] = Instantiate(sandQuad, new Vector3(-6.25f, 0, 100), Quaternion.identity);

        MeshRenderer mr = sandQuad.GetComponentInChildren<MeshRenderer>();
        float x = mr.bounds.size.x;

        tileQueue[1] = Instantiate(sandQuad, new Vector3(-6.25f + x, 0, 100), Quaternion.identity);
        tileQueue[2] = Instantiate(sandQuad, new Vector3(-6.25f + (2 * x), 0, 100), Quaternion.identity);
        tileQueue[3] = Instantiate(sandQuad, new Vector3(-6.25f + (3 * x), 0, 100), Quaternion.identity);


    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (isOffScreenLeft(tileQueue[0]))
        {
            sentTileToBack();
            shiftQueue();
        }
    }

    void sentTileToBack()
    {
        MeshRenderer mr = tileQueue[3].GetComponentInChildren<MeshRenderer>();
        Vector2 x = mr.bounds.max;
        float newX = x[0];

        Transform tf = tileQueue[0].GetComponent<Transform>();
        float y = tf.position.y;
        float z = tf.position.z;

        //Debug.Log(newX);

        tf.position = new Vector3(newX, y,z);
    }

    void shiftQueue()
    {
        GameObject temp= tileQueue[0];
        tileQueue[0] = tileQueue[1];
        tileQueue[1] = tileQueue[2];
        tileQueue[2] = tileQueue[3];
        tileQueue[3] = temp;
    }

    bool isOffScreenLeft(GameObject tile)
    {
        MeshRenderer mr = tile.GetComponentInChildren<MeshRenderer>();
        Vector2 x = mr.bounds.max;
        if (x.x <= -9.0f)
        {
            //Debug.Log(tile.ToString() + " is off-screen.");
            return true;
        }
        return false;
    }
}
