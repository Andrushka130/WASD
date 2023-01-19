using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract string Name { get; }
    public abstract int WeaponLevel { get; }
    public abstract float Dmg { get; }
    protected abstract float CritDmg { get; }
    protected abstract int CritChance { get; }
    protected abstract float Lifesteal { get; }
    protected abstract float AtkSpeed { get; }    
    protected abstract rarity RarityType { get; }

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

    public enum rarity
    {
        common,
        uncommon,
        rare,
        epic,
        legendary
    }
    
}
