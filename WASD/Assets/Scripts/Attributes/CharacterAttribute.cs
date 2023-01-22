using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttribute
{
    private Attribute maxHealth = new Attribute(30);
    private Attribute attack = new Attribute(1);
    private Attribute critChance = new Attribute(1);
    private Attribute critDamage = new Attribute(1);
    private Attribute attackSpeed = new Attribute(1);

    private Attribute armor = new Attribute(1);
    private Attribute dodge = new Attribute(1);
    private Attribute shield = new Attribute(1);
    private Attribute healthRegen = new Attribute(1);
    private Attribute lifesteal = new Attribute(1);

    private Attribute luck = new Attribute(1);
    private Attribute movementSpeed = new Attribute(1);
    private Attribute range = new Attribute(1);
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
    public int MaxHealthValue
    {
        get {return maxHealth.GetValue();}
    }
    public int AttackValue
    {
        get {return attack.GetValue();}
    }
    public int CritChanceValue
    {
        get {return critChance.GetValue();}
    }
    public int CritDamageValue
    {
        get {return critDamage.GetValue();}
    }
    public int AttackSpeedValue
    {
        get {return attackSpeed.GetValue();}
    }
    public int ArmorValue
    {
        get {return armor.GetValue();}
    }
    public int DodgeValue
    {
        get {return dodge.GetValue();}
    }
    public int ShieldValue
    {
        get {return shield.GetValue();}
    }
    public int HealthRegenValue
    {
        get {return healthRegen.GetValue();}
    }
    public int LifestealValue
    {
        get {return lifesteal.GetValue();}
    }
    public int LuckValue
    {
        get {return luck.GetValue();}
    }
    public int MovementSpeedValue
    {
        get {return movementSpeed.GetValue();}
    }
    public int RangeValue
    {
        get {return range.GetValue();}
    }
    public int PsychoLevelValue
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
