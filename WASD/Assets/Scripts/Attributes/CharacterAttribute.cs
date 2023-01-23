using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttribute
{
    private Attribute maxHealth = new Attribute(20);
    private Attribute attack = new Attribute(1);
    private Attribute critChance = new Attribute(1.02f);
    private Attribute critDamage = new Attribute(2);
    private Attribute attackSpeed = new Attribute(0.98f);

    private Attribute armor = new Attribute(2);
    private Attribute dodge = new Attribute(4);
    private Attribute shield = new Attribute(10);
    private Attribute healthRegen = new Attribute(5);
    private Attribute lifesteal = new Attribute(2);

    private Attribute luck = new Attribute(4);
    private Attribute movementSpeed = new Attribute(13);
    private Attribute range = new Attribute(3);
    private Attribute psychoLevel = new Attribute(1);

    protected Attribute MaxHealth
    {
        get {return maxHealth;}
    }
    protected Attribute Attack
    {
        get {return attack;}
    }
    protected Attribute CritChance
    {
        get {return critChance;}
    }
    protected Attribute CritDamage
    {
        get {return critDamage;}
    }
    protected Attribute AttackSpeed
    {
        get {return attackSpeed;}
    }
    protected Attribute Armor
    {
        get {return armor;}
    }
    protected Attribute Dodge
    {
        get {return dodge;}
    }
    protected Attribute Shield
    {
        get {return shield;}
    }
    protected Attribute HealthRegen
    {
        get {return healthRegen;}
    }
    protected Attribute Lifesteal
    {
        get {return lifesteal;}
    }
    protected Attribute Luck
    {
        get {return luck;}
    }
    protected Attribute MovementSpeed
    {
        get {return movementSpeed;}
    }
    protected Attribute Range
    {
        get {return range;}
    }
    protected Attribute PsychoLevel
    {
        get {return psychoLevel;}
    }
    public float MaxHealthValue
    {
        get {return maxHealth.GetValue();}
    }
    public float AttackValue
    {
        get {return attack.GetValue();}
    }
    public float CritChanceValue
    {
        get {return critChance.GetValue();}
    }
    public float CritDamageValue
    {
        get {return critDamage.GetValue();}
    }
    public float AttackSpeedValue
    {
        get {return attackSpeed.GetValue();}
    }
    public float ArmorValue
    {
        get {return armor.GetValue();}
    }
    public float DodgeValue
    {
        get {return dodge.GetValue();}
    }
    public float ShieldValue
    {
        get {return shield.GetValue();}
    }
    public float HealthRegenValue
    {
        get {return healthRegen.GetValue();}
    }
    public float LifestealValue
    {
        get {return lifesteal.GetValue();}
    }
    public float LuckValue
    {
        get {return luck.GetValue();}
    }
    public float MovementSpeedValue
    {
        get {return movementSpeed.GetValue();}
    }
    public float RangeValue
    {
        get {return range.GetValue();}
    }
    public float PsychoLevelValue
    {
        get {return psychoLevel.GetValue();}
    }

    /* void Awake()
    {
        maxHealth = new Attribute();
        attack = new Attribute();
        critChance = new Attribute();
        critDamage = new Attribute();
        attackSpeed = new Attribute();

        armor = new Attribute();
        dodge = new Attribute();
        shield = new Attribute();
        healthRegen = new Attribute();
        lifesteal = new Attribute();

        luck = new Attribute();
        movementSpeed = new Attribute();
        range = new Attribute();
        psychoLevel = new Attribute();
        currentHealth = maxHealth.GetValue();
    }*/

    /* void OnCollisionEnter2D(Collision2D collision)
    {
        //combat method
        //if(collision){TakeDamage(damage)}
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    } */

    /* public void TakeDamage (int damage)
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
    } */
}
