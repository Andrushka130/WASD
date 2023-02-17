using UnityEngine;


public class EnemyFactory : MonoBehaviour
{

    public GameObject meleeEnemy;
    public GameObject rangedEnemy;
    public GameObject boss1;

    [SerializeField] private float maxSpawnRadius = 20f;
    [SerializeField] private float minPlayerDistance = 5f;
    private Transform spawnOrigin;
    private float spawnPointX;
    private float spawnPointY;
    private float spawnOriginX;
    private float spawnOriginY;

    
    public void SpawnEnemy(string enemy)
    {
        spawnOrigin = GameObject.FindWithTag("Player").transform;

        int randomValueX = Random.Range(0, 2);
        spawnPointX = (randomValueX == 0 ? -1 : 1) * Random.Range(0, maxSpawnRadius);

        int randomValueY = Random.Range(0, 2);
        spawnPointY = (randomValueY == 0 ? -1 : 1) * Random.Range(0, maxSpawnRadius/2);

        spawnOriginX = spawnOrigin.transform.position.x;
        spawnOriginY = spawnOrigin.transform.position.y;


        while(spawnOriginX - spawnPointX < minPlayerDistance && spawnOriginY - spawnPointY < minPlayerDistance)
        {
            
            randomValueX = Random.Range(0, 2);
            spawnPointX = (randomValueX == 0 ? -1 : 1) * Random.Range(0, maxSpawnRadius);

            randomValueY = Random.Range(0, 2);
            spawnPointY = (randomValueY == 0 ? -1 : 1) * Random.Range(0, maxSpawnRadius/2);
        }

        switch(enemy)
        {
            case "Melee":

                GameObject melee = Instantiate
                    (
                        meleeEnemy,
                        new Vector2(spawnPointX, spawnPointY),
                        Quaternion.identity
                    );

            break;

            case "Ranged":

                GameObject ranged = Instantiate
                    (
                        rangedEnemy,
                        new Vector2(spawnPointX, spawnPointY),
                        Quaternion.identity
                    );

            break; 
            
            case "Boss1":

                GameObject boss = Instantiate
                    (
                        boss1,
                        new Vector2(spawnPointX, spawnPointY),
                        Quaternion.identity
                    );
            break;
        }
    }
}

    

