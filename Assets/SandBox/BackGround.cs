using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject backGroundMesh;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mRenderer = backGroundMesh.GetComponent<MeshRenderer>();
        Vector2 startPos = new Vector2(-4, 0);
        Vector2 nextPos;
        Instantiate(backGroundMesh, startPos, Quaternion.identity);
        Vector3 rightSide = mRenderer.bounds.max;
        //Debug.Log(rightSide);

        nextPos = new Vector2(8.6f, 0);
        Instantiate(backGroundMesh, nextPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
