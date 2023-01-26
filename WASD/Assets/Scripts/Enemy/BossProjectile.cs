using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public GameObject enemyProjectile;
    public GameObject secondProjectile;
    public SpriteRenderer ProjectileSprite;
    public Rigidbody2D ProjectileBody;
    public CircleCollider2D ProjectileCollider;
    [SerializeField] private int projectileDamage;
    [SerializeField] private float decayTime;
    [SerializeField] private int bulletAmount = 10;

    

    void Awake()
    {
        //CharacterAttribute damagePlayer = GameObject.FindWithTag

        ProjectileBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        enemyProjectile.tag = "EnemyProjectile";
        enemyProjectile.layer = LayerMask.NameToLayer("Player");

        transform.localScale = new Vector2(0.6f, 0.6f);
    }

    public void Initialize(Vector3 position)
    {
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    
        Debug.Log("hit" + collision.gameObject);
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
        if(decayTime > 3f)
        {
            Destroy(gameObject);
        }
    }

}