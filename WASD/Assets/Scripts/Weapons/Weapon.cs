using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract string Category { get; }
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
    private float Timer {get; set;}
    public abstract Sprite Icon { get; }

    private System.Random rnd = new System.Random();
    private Characters currentChar = CharactersManager.CurrentChar;
    
    public abstract void InstantiateWeaponPrefab();
    public  void Attack() {
        Timer += Time.deltaTime;
        if (Timer > GetCooldown())
        {
            InstantiateWeaponPrefab();            
            Timer = 0;
        }
    }
    
    public void DestroyScript(){
        Destroy(this);
    }

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
