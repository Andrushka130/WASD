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
        textField.text = ("Wave: " + GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>().waveCounter);
    }
}
