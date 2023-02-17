using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private float waveCoolDown = 3f;
    [SerializeField] private float startWaveSpawn = 10f;
    [SerializeField] private int bossIntervall = 2;
    [SerializeField] private float spawnIncrease = 1.2f;
    [SerializeField] private float bossSpawnIncrease = 1.2f;
    [SerializeField] private bool enemySpawning;
    [SerializeField] private int enemySpawnCap = 5;
    public bool bossSpawning;
    private float waveSpawn;
    private float spawnSpace;
    private float bossWaveSpawn;
    private float bossSpawnSpace;
    protected int bossWaveCountDown;
    public ulong waveCounter;
    protected ulong currentWave;
    private int enemyCount;
    private EnemyFactory enemyFactory;

    void Awake()
    {
        waveCounter = 0;
        currentWave = waveCounter;
        bossWaveCountDown = bossIntervall;

        waveSpawn = startWaveSpawn;
        enemySpawning = true;
        spawnSpace = waveSpawn;

        bossWaveSpawn = 1f;
        bossSpawning = true;
        bossSpawnSpace = bossWaveSpawn;

        StartCoroutine(WaveSpawner());
    }

    void Update()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        enemyCount = enemies.Length;
    }

    IEnumerator WaveSpawner()
    {
        while (enemySpawning == true)
        {
            while(spawnSpace >= 1f)
            {
                int randEnemy = Random.Range(0, 2);
                
                if (spawnSpace < 2f)
                {
                    randEnemy = 0;
                }
                yield return new WaitUntil(() => enemyCount < enemySpawnCap - 1);

                switch(randEnemy)
                {
                    case 0:
                    gameObject.GetComponent<EnemyFactory>().SpawnEnemy("Melee");
                    spawnSpace -= 1;
                    break;

                    case 1:
                    gameObject.GetComponent<EnemyFactory>().SpawnEnemy("Ranged");
                    spawnSpace -= 2;
                    break;
                }
            }

            if(bossWaveCountDown <= 0)
            {
                while (bossSpawnSpace >= 1)
                {
                    int randBoss = Random.Range(0, 1);
                    switch(randBoss)
                    {
                        case 0:
                        gameObject.GetComponent<EnemyFactory>().SpawnEnemy("Boss1");
                        FindObjectOfType<AudioManager>().Play("BossSpawns");
                        bossSpawnSpace -= 1; 
                        break;
                    }
                    bossWaveCountDown = bossIntervall;
                }
                bossWaveCountDown = bossIntervall;
                bossWaveSpawn = bossWaveSpawn * bossSpawnIncrease;
                bossSpawnSpace = bossWaveSpawn;
            }

            waveCounter++;
            currentWave = waveCounter;
            waveSpawn = waveSpawn * spawnIncrease;
            spawnSpace = waveSpawn;

            bossWaveCountDown -= 1;
        
            yield return new WaitUntil(() => enemyCount == 0);

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
        waveCounter = 0;
        currentWave = waveCounter;
        bossWaveCountDown = bossIntervall;

        waveSpawn = startWaveSpawn;
        enemySpawning = true;
        spawnSpace = waveSpawn;

        bossWaveSpawn = 1f;
        bossSpawning = true;
        bossSpawnSpace = bossWaveSpawn;
        
        enemySpawning = true;
    }
}
