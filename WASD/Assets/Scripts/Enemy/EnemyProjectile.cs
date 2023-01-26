using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject enemyProjectile;
    public SpriteRenderer ProjectileSprite;
    public Rigidbody2D ProjectileBody;
    public CircleCollider2D ProjectileCollider;
    public int projectileDamage;
    private float decayTime;

    

    void Awake()
    {
        //CharacterAttribute damagePlayer = GameObject.FindWithTag

        ProjectileBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        /* enemyProjectile.tag = "EnemyProjectile";
        enemyProjectile.layer = LayerMask.NameToLayer("Player"); */

        transform.localScale = new Vector2(0.3f, 0.3f);

        ignorePhysicsOfEnemyAndAttacks();
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

}
