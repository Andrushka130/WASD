using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField]
    public int health = 5;
    private int currentHealth;

    void Start()
    {
        currentHealth = health;
    }

    public int getHealth()
    {
        return this.health;
    }

    public void setHealth(int newHealth)
    {
        this.health = newHealth;
    }

    public int updateHealth(int newHealth)
    {
        this.health = newHealth;
        return this.health;
    }

    public void DamageEnemy(int damage)
    {
        currentHealth -= damage;
    }

    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
