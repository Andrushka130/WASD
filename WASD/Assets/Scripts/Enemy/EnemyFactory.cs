using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFactory : MonoBehaviour
{

    public GameObject meleeEnemy;
    public GameObject rangedEnemy;
    public GameObject boss1;

    public float maxSpawnRadius = 20f;
    public float minPlayerDistance = 5f;
    public float waveCoolDown = 10f;
    public float startWaveSpawn = 10f;
    public float spawnIncrease = 1.2f;
    public bool enemySpawning;
    private float waveSpawn;
    private float spawnSpace;
    protected int waveCounter;
    protected int currentWave;
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
    }

        public void SpawnEnemy(string enemy)
        {
            //Create random spawnPoint with distance to player
            spawnOrigin = GameObject.FindWithTag("Player").transform;
        
            spawnPointX = (Random.Range(0, 2) * 2 - 1) * Random.Range(0, maxSpawnRadius);
            spawnPointY = ((Random.Range(0, 2) * 2 - 1) * Random.Range(0, maxSpawnRadius))/2;

            spawnOriginX = spawnOrigin.transform.position.x;
            spawnOriginY = spawnOrigin.transform.position.y;


            while(spawnOriginX - spawnPointX < minPlayerDistance && spawnOriginY - spawnPointY < minPlayerDistance)
            {
                spawnPointX = (Random.Range(0, 2) * 2 - 1) * Random.Range(0, maxSpawnRadius);
                spawnPointY = ((Random.Range(0, 2) * 2 - 1) * Random.Range(0, maxSpawnRadius))/2;
            }

            switch(enemy)
            {
                case "Melee":

                //Enemy<Melee> meleeEnemy = new Enemy<Melee>("MeleeEnemy");
                    Instantiate
                        (
                            meleeEnemy,
                            new Vector2(spawnPointX, spawnPointY),
                            Quaternion.identity
                        );

                break;

                case "Ranged":

                //Enemy<Ranged> rangedEnemy = new Enemy<Ranged>("RangedEnemy");
                    Instantiate
                        (
                            rangedEnemy,
                            new Vector2(spawnPointX, spawnPointY),
                            Quaternion.identity
                        );

                break; 
                
                case "Boss1":

                //Enemy<Boss1> boss1 = new Enemy<Boss1>("Boss1");
                    Instantiate
                        (
                            boss1,
                            new Vector2(spawnPointX, spawnPointY),
                            Quaternion.identity
                        );

                break;
            }

           
        }


                    

    }

    

