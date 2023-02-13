using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{

    public float waveCoolDown = 10f;
    public float startWaveSpawn = 10f;
    public int bossIntervall = 2;
    public float spawnIncrease = 1.2f;
    public float bossSpawnIncrese = 1.1f;
    public bool enemySpawning;
    public bool bossSpawning;
    public float bossSpawnIncrease = 1.2f;
    private float waveSpawn;
    private float spawnSpace;
    private float bossWaveSpawn;
    private float bossSpawnSpace;
    public ulong waveCounter;
    protected int bossWaveCountDown;
    protected ulong currentWave;
    private EnemyFactory enemyFactory;

    void Awake()
    {
        //Wave related settings
        waveCounter = 0;
        currentWave = waveCounter;
        bossWaveCountDown = bossIntervall;

        //Standart enemy related settings
        waveSpawn = startWaveSpawn;
        enemySpawning = true;
        spawnSpace = waveSpawn;

        //Boss related settings
        bossWaveSpawn = 1f;
        bossSpawning = true;
        bossSpawnSpace = bossWaveSpawn;

        StartCoroutine(WaveSpawner());
    }


    IEnumerator WaveSpawner()
    {
        while (enemySpawning == true)
        {
            while (spawnSpace >= 1) 
            {
                int randEnemy = Random.Range(0, 2);
                switch(randEnemy)
                {
                    case 0:
                    //Spawn MeleeEnemy with factory
                    gameObject.GetComponent<EnemyFactory>().SpawnEnemy("Melee");
                    //enemyFactory.SpawnEnemy("Melee");
                    spawnSpace -= 1;
                    break;

                    case 1:
                    //Spawn RangedEnemy with factory
                    gameObject.GetComponent<EnemyFactory>().SpawnEnemy("Ranged");
                    //enemyFactory.SpawnEnemy("Ranged");
                    spawnSpace -= 2;
                    break;
                }
                yield return new WaitForSeconds(0.3f);
                //Debug.Log(spawnSpace);
            }

            if(bossWaveCountDown <= 0)
            {
                while (bossSpawnSpace >= 1)
                {
                    int randBoss = Random.Range(0, 1);
                    switch(randBoss)
                    {
                        case 0:
                        //Spawn first Boss with factory
                        gameObject.GetComponent<EnemyFactory>().SpawnEnemy("Boss1");
                        FindObjectOfType<AudioManager>().Play("BossSpawns");
                        //enemyFactory.SpawnEnemy("Boss1");
                        //adjust for boss difficulty level
                        bossSpawnSpace -= 1; 
                        break;
                    }
                    bossWaveCountDown = bossIntervall;
                    yield return new WaitForSeconds(0.3f);
                }
                bossWaveCountDown = bossIntervall;
                bossWaveSpawn = bossWaveSpawn * bossSpawnIncrease;
                bossSpawnSpace = bossWaveSpawn;
            }

            waveCounter++;
            currentWave = waveCounter;
            //Debug.Log("W"+waveSpawn);
            waveSpawn = waveSpawn * spawnIncrease;
            spawnSpace = waveSpawn;
            //Debug.Log(spawnSpace);

            bossWaveCountDown -= 1;
            
            while(GameObject.FindWithTag("Enemy") != null)
            {
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(waveCoolDown);
            Time.timeScale = 0f;
            SceneManager.LoadSceneAsync("Shop", LoadSceneMode.Additive);

        }
        
    }

    public void DisableWaveSpawning()
    {
        enemySpawning = false;
    }

    public void EnableWaveSpawning()
    {
        //Wave related settings
        waveCounter = 0;
        currentWave = waveCounter;
        bossWaveCountDown = bossIntervall;

        //Standart enemy related settings
        waveSpawn = startWaveSpawn;
        enemySpawning = true;
        spawnSpace = waveSpawn;

        //Boss related settings
        bossWaveSpawn = 1f;
        bossSpawning = true;
        bossSpawnSpace = bossWaveSpawn;
        
        enemySpawning = true;
    }
}
