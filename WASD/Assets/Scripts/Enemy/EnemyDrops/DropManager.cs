using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField] private GameObject experience;
    [SerializeField] private GameObject currency;
    [SerializeField] private GameObject health;
    [SerializeField] private byte expAmount;
    [SerializeField] private byte curAmount;
    [SerializeField] private byte healtAmount;
    private float spawnOriginX;
    private float spawnOriginY;

    public void Drop()
    {
        if (gameObject.name == "MeeleEnemy(Clone)")
        {
            expAmount = 3;
            curAmount = 1;
            healtAmount = 1;
        }
        else if (gameObject.name == "RangeEnemy(Clone)")
        {
            expAmount = 4;
            curAmount = 2;
            healtAmount = 2;
        }
        else if (gameObject.name == "Boss(Clone)")
        {
            expAmount = 7;
            curAmount = 5;
            healtAmount = 3;
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
        for (int j = 1; j <= healtAmount; j++)
        {
            Vector3 curSpawn = new Vector3(Random.Range(spawnOriginX - 0.3f, spawnOriginX + 0.3f), Random.Range(spawnOriginY + 0.3f, spawnOriginY - 0.3f), 0);
            GameObject newCur = (GameObject)Instantiate(health, curSpawn, Quaternion.identity);
        }
    }
}

