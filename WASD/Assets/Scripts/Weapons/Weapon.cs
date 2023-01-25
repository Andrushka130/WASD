using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract int WeaponLevel { get; }
    public abstract int Value { get; }
    public abstract float Dmg { get; }
    public abstract float CritDmg { get; }
    public abstract int CritChance { get; }
    public abstract float Lifesteal { get; }
    public abstract float AtkSpeed { get; }    
    public abstract Rarity RarityType { get; }

    public abstract Sprite Icon { get; }



    private System.Random rnd = new System.Random();
    private Characters currentChar = CharactersManager.CurrentChar;
    

    public abstract void Attack();
    
    public abstract void DestroyScript();

    public float GetDamage()
    {
        int random = rnd.Next(1, 101);
        if(random < (CritChance * currentChar.CritChanceValue) )
        {
            return CritDmg * GetPercentage(currentChar.CritDamageValue);
        }
        return Dmg * GetPercentage(currentChar.AttackValue);
    }

    public float GetCooldown()
    {
        return AtkSpeed / GetPercentage(currentChar.AttackSpeedValue);
    }

    private float GetPercentage(int value)
    {
        return (value + 100) / 100;
    }
}
