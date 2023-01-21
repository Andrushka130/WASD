using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Rigidbody2D Body;
    public SpriteRenderer Sprite;
    public CircleCollider2D Collider;
    public int currentHealth;

    protected abstract void MovementPattern();

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




