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

    private System.Random rnd = new System.Random();
    /*private PlayerAttribute _playerAttribute = new PlayerAttribute();*/
    

    public abstract void Attack();
    
    public abstract void DestroyScript();

    public float GetDamage()
    {
        int random = rnd.Next(1, 101);
        if(random < CritChance /*(CritChance * _playerAttribute.CritChance)*/ )
        {
            return Dmg * CritDmg /* + _playerAttribute.Damage*/;
        }
        return Dmg /* + _playerAttribute.Damage*/;
    }

    public float GetCooldown()
    {
        return AtkSpeed /* * _playerAttribute.Attackspeed*/;
    }
}