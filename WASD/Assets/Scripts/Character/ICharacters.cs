using System.Collections.Generic;
using UnityEngine;

public interface ICharacters
{
    public Sprite Icon { get; }
    public Sprite CharSprite { get; }
    public Attribute MaxHealth { get; }
    public Attribute Attack { get; }
    public Attribute CritChance { get; }
    public Attribute CritDamage { get; }
    public Attribute AttackSpeed { get; }
    public Attribute Luck { get; }
    public Attribute MovementSpeed { get; }
    public Attribute MaxPsychoLevel { get; }
    public Attribute CurrentPsychoLevel { get; }

    
    public float MaxHealthValue { get; }
    public float AttackValue { get; }
    public float CritChanceValue { get; }
    public float CritDamageValue { get; }
    public float AttackSpeedValue { get; }
    public float LuckValue { get; }
    public float MovementSpeedValue { get; }
    public float MaxPsychoLevelValue { get; }
    public float CurrentPsychoLevelValue { get; }

    public List<Attribute> GetAttributes();
}