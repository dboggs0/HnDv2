using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text txt = gameObject.GetComponent<Text>();
        txt.text = "Wave 1 of 20";
        EnemySpawner.newWave += showWaveInfo;
    }

    private void OnDestroy()
    {
        EnemySpawner.newWave -= showWaveInfo;
    }

    private void showWaveInfo(int waveNum)
    {
        Text txt = gameObject.GetComponent<Text>();
        txt.text = "Wave " + waveNum.ToString() + " of 20";
    }
}
