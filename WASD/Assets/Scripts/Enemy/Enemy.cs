using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Rigidbody2D Body;
    public SpriteRenderer Sprite;
    public CircleCollider2D Collider;
    public float currentHealth;

    protected abstract void MovementPattern();

    public virtual void Initialize(Vector3 position)
    {
        transform.position = position;
    }

    public void HealthUpdate(float maxHealth)
    {
        maxHealth = currentHealth;
        if (maxHealth <= 0)
        {
            gameObject.GetComponent<DropManager>().Drop();
            Destroy(gameObject);
        }
    }
    
    public void DamageEnemy(float bulletDamage)
    {
        currentHealth -= bulletDamage;
    }
}




