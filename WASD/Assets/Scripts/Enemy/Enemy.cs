using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy<T> where T : Enemy
{
    public GameObject GameObject;
    public T ScriptComponent;

    public Enemy(string name)
    {
        GameObject = new GameObject(name);
        ScriptComponent = GameObject.AddComponent<T>();
    }
}

public abstract class Enemy : MonoBehaviour
{
    public Rigidbody2D Body;
    public SpriteRenderer Sprite;
    public CircleCollider2D Collider;
    public int currentHealth;

    protected abstract void MovementPattern();

    void Awake()
    {
        //Add common components
        Body = gameObject.AddComponent<Rigidbody2D>();
        Sprite = gameObject.AddComponent<SpriteRenderer>();
        Collider = gameObject.AddComponent<CircleCollider2D>();
        currentHealth = 1;

        //Set common sprite
        Sprite.sprite = Resources.Load<Sprite>("Enemy_Default");
        Body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        gameObject.tag = "Enemy";
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public virtual void Initialize(Vector3 position)
    {
        transform.position = position;
    }

    public void HealthUpdate(int maxHealth)
    {
        maxHealth = currentHealth;
        if (maxHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void DamageEnemy(int bulletDamage)
    {
        currentHealth -= bulletDamage;
    }

}




