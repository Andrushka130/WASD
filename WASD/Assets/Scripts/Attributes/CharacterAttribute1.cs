using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttribute1 : MonoBehaviour
{
    public Attribute maxHealth;
    public int currentHealth {get; private set; }
    
    public Attribute attack;
    public Attribute critChance;
    public Attribute critDamage;
    public Attribute attackSpeed;

    public Attribute armor;
    public Attribute dodge;
    public Attribute shield;
    public Attribute healthRegen;
    public Attribute lifesteal;

    public Attribute luck;
    public Attribute movementSpeed;
    public Attribute range;
    public Attribute psychoLevel;

    void Awake()
    {
        currentHealth = maxHealth.GetValue();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //combat method
        //if(collision){TakeDamage(damage)}
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage (int damage)
    {
        float randomNumber = Random.Range(0, 100);
        if(randomNumber < dodge.GetValue())
        {
            damage = 0;
        }else
        {           
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        }

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Die in some way
        //This method is meant to be overritten
        Debug.Log(transform.name + " died.");
    }
}
