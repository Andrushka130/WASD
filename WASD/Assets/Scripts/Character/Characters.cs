using System.Collections.Generic;
using UnityEngine;

public abstract class Characters : ICharacters
{
    public abstract Sprite Icon { get; }
    public abstract Sprite CharSprite { get; }
    public abstract Attribute MaxHealth { get; }
    public abstract Attribute Attack { get; }
    public abstract Attribute CritChance { get; }
    public abstract Attribute CritDamage { get; }
    public abstract Attribute AttackSpeed { get; }
    public abstract Attribute Luck { get; }
    public abstract Attribute MovementSpeed { get; }
    public abstract Attribute MaxPsychoLevel { get; }
    public Attribute CurrentPsychoLevel => new Attribute(0, "");
    
    public float MaxHealthValue { get { return MaxHealth.GetValue(); } }
    public float AttackValue { get {return Attack.GetValue();} }
    public float CritChanceValue { get {return CritChance.GetValue();} }
    public float CritDamageValue { get {return CritDamage.GetValue();} }
    public float AttackSpeedValue { get {return AttackSpeed.GetValue();} }
    public float LuckValue { get {return Luck.GetValue();} }
    public float MovementSpeedValue { get {return MovementSpeed.GetValue();} }
    public float MaxPsychoLevelValue { get {return MaxPsychoLevel.GetValue();} }
    public float CurrentPsychoLevelValue { get { return CurrentPsychoLevel.GetValue(); ; } }

    public abstract List<Attribute> GetAttributes();
}