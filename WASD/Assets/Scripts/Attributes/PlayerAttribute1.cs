using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute1 : CharacterAttribute1
{
    public void OnItemAdded (Item newItem)
    {
        if (newItem != null)
        {
            maxHealth.AddModifier(newItem.maxHealth);
            
            attack.AddModifier(newItem.attack);
            critChance.AddModifier(newItem.critChance);
            critDamage.AddModifier(newItem.critDamage);
            attackSpeed.AddModifier(newItem.attackSpeed);

            armor.AddModifier(newItem.armor);
            dodge.AddModifier(newItem.dodge);
            shield.AddModifier(newItem.shield);
            healthRegen.AddModifier(newItem.healthRegen);
            lifesteal.AddModifier(newItem.lifesteal);

            luck.AddModifier(newItem.luck);
            movementSpeed.AddModifier(newItem.movementSpeed);
            psychoLevel.AddModifier(newItem.psychoLevel);
        }
    }
}
