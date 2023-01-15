using UnityEngine;

public class CharacterAttribute : MonoBehaviour
{
    public int maxHealth;
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
        currentHealth = maxHealth;
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
