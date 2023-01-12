using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFactory : MonoBehaviour
{

    public float maxSpawnRadius = 20f;
    public float minPlayerDistance = 5f;
    public int meleeSpawnRate = 10;
    public int rangedSpawnRate = 5;
    public float waveCoolDown = 10f;
    public float startWaveSpawn = 10f;
    public float waveSpawn;
    public float spawnIncrease = 1.2f;
    private float spawnSpace;
    public int waveCounter;
    public int currentWave;
    public bool enemySpawning;
    private Transform spawnOrigin;
    private float spawnPointX;
    private float spawnPointY;
    private float spawnOriginX;
    private float spawnOriginY;

    void Awake()
    {
        waveCounter = 0;
        waveSpawn = startWaveSpawn;
        currentWave = waveCounter;
        enemySpawning = true;
        spawnSpace = waveSpawn;
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {

        while(enemySpawning == true)
        {

        while (spawnSpace > 0) 
        {

            spawnOrigin = GameObject.FindWithTag("Player").transform;
        
        spawnPointX = (Random.Range(0, 2) * 2 - 1) * Random.Range(0, maxSpawnRadius);
        spawnPointY = ((Random.Range(0, 2) * 2 - 1) * Random.Range(0, maxSpawnRadius))/2;

        spawnOriginX = spawnOrigin.transform.position.x;
        spawnOriginY = spawnOrigin.transform.position.y;


        while(spawnOriginX - spawnPointX < minPlayerDistance && spawnOriginY - spawnPointY < minPlayerDistance)
        {
            spawnPointX = (Random.Range(0, 2) * 2 - 1) * Random.Range(0, maxSpawnRadius);
            spawnPointY = ((Random.Range(0, 2) * 2 - 1) * Random.Range(0, maxSpawnRadius))/2;
            //Debug.Log("SpawnPoint reset.");
        }

            int randEnemy = Random.Range(0, 1);
            switch (randEnemy) 
            {
                case 0:

                    Enemy<Melee> meleeEnemy = new Enemy<Melee>("MeleeEnemy");
                    meleeEnemy.ScriptComponent.Initialize
            (
                position : new Vector2(spawnPointX, spawnPointY)
            );
                spawnSpace -= 1;

                    yield return new WaitForSeconds(0.3f);
                    Debug.Log("MeleeEnemy spawned");

                break;

                case 1:
                    Enemy<Ranged> rangedEnemy = new Enemy<Ranged>("RangedEnemy");
                    rangedEnemy.ScriptComponent.Initialize
                    (
                        position : new Vector2(spawnPointX, spawnPointY)
                    );
                        spawnSpace -= 2;

                    yield return new WaitForSeconds(0.3f);
                    Debug.Log("RangedEnemy spawned");
                break;
            }
        }
        yield return new WaitForSeconds(waveCoolDown);
        waveCounter++;
        currentWave = waveCounter;
        waveSpawn = waveSpawn * spawnIncrease;
        spawnSpace = waveSpawn;
        while(GameObject.FindWithTag("Enemy") != null)
        {
            yield return new WaitForSeconds(1);
        }
        }
        }
}
    

