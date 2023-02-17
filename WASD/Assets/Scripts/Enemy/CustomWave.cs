using UnityEngine;

public class CustomWave : MonoBehaviour
{
    public static bool customWave = false;

    public GameObject customWaveUI;
    public bool spawningActive;

    void Start()
    {
        customWaveUI.SetActive(false);
        spawningActive = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            if(customWave)
            {
                Resume();
            }
            else
            {
                CustomWaveMode();
            }
        }
    }

    void Resume()
    {
        customWaveUI.SetActive(false);
        Time.timeScale = 1f;
        customWave = false;
    }

    void CustomWaveMode()
    {
        customWaveUI.SetActive(true);
        Time.timeScale = 0f;
        customWave = true;
    }

    public void ClearEnemies()
    {
        Time.timeScale = 1f;
        

        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        
        Time.timeScale = 0f;
    }

    public void ToggleWaveSpawning()
    {
        Time.timeScale = 1f;

        if(spawningActive)
        {
            DisableWave();
        }
        else
        {
            EnableWave();
        }
    }

    public void DisableWave()
    {
        Time.timeScale = 1f;
        GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>().DisableWaveSpawning();
        spawningActive = false;
        Time.timeScale = 0f;
    }

    public void EnableWave()
    {
        Time.timeScale = 1f;
        GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>().EnableWaveSpawning();
        spawningActive = true;
        Time.timeScale = 0f;
    }

    public void CustomSpawnMelee()
    {
        Time.timeScale = 1f;
        GameObject.FindWithTag("SpawnManager").GetComponent<EnemyFactory>().SpawnEnemy("Melee");
        Time.timeScale = 0f;
    }

    public void CustomSpawnRanged()
    {
        Time.timeScale = 1f;
        GameObject.FindWithTag("SpawnManager").GetComponent<EnemyFactory>().SpawnEnemy("Ranged");
        Time.timeScale = 0f;
    }

    public void CustomSpawnBoss()
    {
        Time.timeScale = 1f;
        GameObject.FindWithTag("SpawnManager").GetComponent<EnemyFactory>().SpawnEnemy("Boss1");
        Time.timeScale = 0f;
    }
}