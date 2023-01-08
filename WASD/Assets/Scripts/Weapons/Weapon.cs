using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected abstract string Name { get; }
    public abstract float Dmg { get; }
    protected abstract float CritDmg { get; }
    protected abstract float CritChance { get; }
    protected abstract float Lifesteal { get; }
    protected abstract float AtkSpeed { get; }
    protected abstract int UpgradeLevel { get; }
    protected abstract rarity RarityType { get; }

    public abstract void attack();

    public enum rarity
    {
        common,
        uncommon,
        rare,
        epic,
        legendary
    }
    
}
