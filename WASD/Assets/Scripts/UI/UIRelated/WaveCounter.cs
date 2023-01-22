using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour
{

    public GameObject waveDisplay;
    public TMP_Text textField;

    void Start()
    {
        waveDisplay.SetActive(true);
    }

    void Update()
    {
        /*if(GameObject.FindWithTag("Canvas").GetComponentInParent<CustomWave>().customWave)
        {
            waveDisplay.SetActive(false);
        }
        else
        {
            waveDisplay.SetActive(true);
        }*/
        textField.text = ("Wave: " + GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>().waveCounter);
    }
}
