using UnityEngine;

public class CharacterAttribute : MonoBehaviour
{
    private int maxHealth;
    public int CurrentHealth {get; private set; }
    
    private Attribute damage;
    private Attribute critChance;
    private Attribute critDamage;
    private Attribute attackSpeed;

    private Attribute armor;
    private Attribute dodge;
    private Attribute shield;
    private Attribute healthRegen;
    private Attribute lifesteal;

    private Attribute luck;
    private Attribute movementSpeed;
    private Attribute range;
    private Attribute psychoLevel;

    public int MaxHealth
    {
        get {return maxHealth;}
    }
    public int Damage
    {
        get {return damage.GetValue();}
    }
    public int CritChance
    {
        get {return critChance.GetValue();}
    }
    public int CritDamage
    {
        get {return critDamage.GetValue();}
    }
    public int AttackSpeed
    {
        get {return attackSpeed.GetValue();}
    }
    public int Armor
    {
        get {return armor.GetValue();}
    }
    public int Dodge
    {
        get {return dodge.GetValue();}
    }
    public int Shield
    {
        get {return shield.GetValue();}
    }
    public int HealthRegen
    {
        get {return healthRegen.GetValue();}
    }
    public int Lifesteal
    {
        get {return lifesteal.GetValue();}
    }
    public int Luck
    {
        get {return luck.GetValue();}
    }
    public int MovementSpeed
    {
        get {return movementSpeed.GetValue();}
    }
    public int Range
    {
        get {return range.GetValue();}
    }
    public int PsychoLevel
    {
        get {return psychoLevel.GetValue();}
    }

    void Awake()
    {
        CurrentHealth = maxHealth;
    }

    void Update()
    {
        //combat method
        //if(collision){TakeDamage(damage)}
    }

    public void TakeDamage (int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log("Player died");
        currentHealth = maxHealth;
        
        GameObject.FindWithTag("Canvas").GetComponent<GameOver>().GameOverScreen();
    }
}
