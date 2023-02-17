using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject enemyProjectile;
    public SpriteRenderer ProjectileSprite;
    public Rigidbody2D ProjectileBody;
    public CircleCollider2D ProjectileCollider;
    public float projectileDamage;
    [SerializeField] private float decayTime;
    [SerializeField] private float dmgScaling = 1.1f;

    

    void Start()
    {
        ProjectileBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        enemyProjectile.layer = LayerMask.NameToLayer("EnemyProjectile");

        transform.localScale = new Vector2(0.3f, 0.3f);

        ignorePhysicsOfEnemyAndAttacks();
        UpdateStats();
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
        Destroy(gameObject);
    }

    void Update()
    {
        decayTime += Time.deltaTime;
        if(decayTime > 3f)
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
        }
        
    }
}
