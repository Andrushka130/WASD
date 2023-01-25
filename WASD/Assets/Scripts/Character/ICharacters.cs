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

    
    public int MaxHealthValue { get; }
    public int AttackValue { get; }
    public int CritChanceValue { get; }
    public int CritDamageValue { get; }
    public int AttackSpeedValue { get; }
    public int LuckValue { get; }
    public int MovementSpeedValue { get; }
    public int MaxPsychoLevelValue { get; }
    public int CurrentPsychoLevelValue { get; }

    public List<Attribute> GetAttributes();
}