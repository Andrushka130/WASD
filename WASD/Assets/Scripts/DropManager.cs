using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public GameObject experience;
    public GameObject currency;
    public byte expAmount;
    public byte curAmount;
    private float spawnOriginX;
    private float spawnOriginY;

    private void OnDestroy()
    {
        if (gameObject.name == "Enemy(Clone)")
        {
            expAmount = 3;
            curAmount = 1;
        }
        else if (gameObject.name == "Boss(Clone)")
        {
            expAmount = 5;
            curAmount = 3;
        }
        spawnOriginX = gameObject.transform.position.x;
        spawnOriginY = gameObject.transform.position.y;

        for (int i = 1; i <= expAmount; i++)
        {
            Vector3 expSpawn = new Vector3(Random.Range(spawnOriginX - 0.3f, spawnOriginX + 0.3f), Random.Range(spawnOriginY + 0.3f, spawnOriginY - 0.3f), 0);
            GameObject newExp = (GameObject)Instantiate(experience, expSpawn, Quaternion.identity);
        }

        for (int j = 1; j <= curAmount; j++)
        {
            Vector3 curSpawn = new Vector3(Random.Range(spawnOriginX - 0.3f, spawnOriginX + 0.3f), Random.Range(spawnOriginY + 0.3f, spawnOriginY - 0.3f), 0);
            GameObject newCur = (GameObject)Instantiate(currency, curSpawn, Quaternion.identity);
        }
    }
}
