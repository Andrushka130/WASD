using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemy;
    public GameObject boss;
    public float spawnRange;
    public float spawnCoolDown;
    public float waveCoolDown;
    private int bossCountDown;
    public int bossSpawnIntervall = 5;
    //private float maxWaveTime = 300;

    private float spawnsPerWave = 10;
    private float spawnIncrease = 5;
    public int currentWave = 0;

    void Start()
    {
        bossCountDown = bossSpawnIntervall;
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {

            spawnsPerWave = Random.Range(spawnsPerWave, spawnsPerWave * 1.2f);
            spawnIncrease = Random.Range(spawnIncrease, spawnIncrease * 1.2f);

            for (int i = 0; i <+ spawnsPerWave; i++)
            {
                Vector3 enemySpawn = new Vector3(Random.Range(-2 * spawnRange, 2 * spawnRange), Random.Range(-1 * spawnRange, spawnRange), 0);
                GameObject currentEnemy = (GameObject)Instantiate(enemy, enemySpawn, Quaternion.identity);
                yield return new WaitForSeconds(spawnCoolDown);
            }

            if (bossCountDown == 0)
            {
                Vector3 enemySpawn = new Vector3(Random.Range(-2 * spawnRange, 2 * spawnRange), Random.Range(-1 * spawnRange, spawnRange), 0);
                GameObject currentEnemy = (GameObject)Instantiate(boss, enemySpawn, Quaternion.identity);

                bossCountDown = bossSpawnIntervall;
            }

            spawnsPerWave += spawnIncrease;

            currentWave++;
            Debug.Log("Current wave:" + currentWave);

            bossCountDown -= 1;

            while (GameObject.FindWithTag("Enemy") != null)
            {
                yield return new WaitForSeconds(1);

            }
            yield return new WaitForSeconds(waveCoolDown);
        }

        
    }
}
