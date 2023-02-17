using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public GameObject enemyProjectile;
    public GameObject secondProjectile;
    public SpriteRenderer ProjectileSprite;
    public Rigidbody2D ProjectileBody;
    public CircleCollider2D ProjectileCollider;
    [SerializeField] private float projectileDamage;
    [SerializeField] private float decayTime;
    [SerializeField] private int bulletAmount = 20;
    [SerializeField] private float dmgScaling = 1.1f;
    [SerializeField] private float bulletSpreadScaling = 1.5f;
    [SerializeField] private int maxBulletSpread = 20;

    

    void Start()
    {
        ProjectileBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        enemyProjectile.tag = "EnemyProjectile";
        enemyProjectile.layer = LayerMask.NameToLayer("EnemyProjectile");

        ignorePhysicsOfEnemyAndAttacks();
        UpdateStats();

        transform.localScale = new Vector2(0.6f, 0.6f);
    }

    public void Initialize(Vector3 position)
    {
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().DamagePlayer(projectileDamage);
            collision.gameObject.GetComponent<PlayerHealthManager>().UpdateHealth();
        }

        for(int i = 0; i < bulletAmount; i++)
        {
            var radians = 2 * Mathf.PI / bulletAmount * i;

            var vertical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians);

            var spawnDir = new Vector2 (horizontal, vertical);

            var spawnPos = (Vector2)gameObject.transform.position + spawnDir * 0.7f;

            GameObject spreadBullet = Instantiate(secondProjectile, spawnPos, Quaternion.identity);

            spreadBullet.GetComponent<Rigidbody2D>().AddForce((spawnPos - (Vector2)gameObject.transform.position).normalized * 5f, ForceMode2D.Impulse);

        }

        Destroy(gameObject);
    }

    void Update()
    {
        decayTime += Time.deltaTime;
        if(decayTime > 6f)
        {
            Destroy(gameObject);
        }
    }

    private void ignorePhysicsOfEnemyAndAttacks()
    {
        Physics2D.IgnoreLayerCollision(7, 10);
        Physics2D.IgnoreLayerCollision(8, 10);
        Physics2D.IgnoreLayerCollision(10, 10);
    }

    public void UpdateStats()
    {
        float currentScale = GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>().waveCounter;

        if(currentScale > 0f)
        {
            this.projectileDamage = projectileDamage + (currentScale * dmgScaling);
            this.bulletAmount = bulletAmount + (int)(currentScale * bulletSpreadScaling);
        }
        

        if(bulletAmount >= maxBulletSpread)
        {
            bulletAmount = maxBulletSpread;
        }
    }
}