using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponClass : MonoBehaviour
{
    protected abstract string Name { get; }
    protected abstract float Dmg { get; }
    protected abstract float CritDmg { get; }
    protected abstract float CritChance { get; }
    protected abstract float Lifesteal { get; }
    protected abstract float AtkSpeed { get; }
    protected abstract int UpgradeLevel { get; }
    protected abstract rarity RarityType { get; }

    public abstract void attack();
    public abstract void upgradeWeapon(rarity rarityType);

    public enum rarity
    {
        common,
        uncommon,
        rare,
        epic,
        legendary
    }
    
}
