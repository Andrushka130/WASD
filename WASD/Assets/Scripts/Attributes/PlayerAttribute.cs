using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : CharacterAttribute
{
    private static PlayerAttribute instance = null;
    private static readonly object padlock = new object();
    private PlayerAttribute()
    {
    }
    public static PlayerAttribute Instance
    {
        get
        {
        lock (padlock)
        {
            if (instance == null)
            {
            instance = new PlayerAttribute();
            }
            return instance;
        }
        }
    }
    public void OnItemAdded (Item newItem)
    {
        if (newItem != null)
        {
            MaxHealth.AddModifier(newItem.maxHealth);
            
            Attack.AddModifier(newItem.attack);
            CritChance.AddModifier(newItem.critChance);
            CritDamage.AddModifier(newItem.critDamage);
            AttackSpeed.AddModifier(newItem.attackSpeed);

            Armor.AddModifier(newItem.armor);
            Dodge.AddModifier(newItem.dodge);
            Shield.AddModifier(newItem.shield);
            HealthRegen.AddModifier(newItem.healthRegen);
            Lifesteal.AddModifier(newItem.lifesteal);

            Luck.AddModifier(newItem.luck);
            MovementSpeed.AddModifier(newItem.movementSpeed);
            PsychoLevel.AddModifier(newItem.psychoLevel);
        }
    }
}
