using System.Collections.Generic;
using UnityEngine;
using AttributeResources;

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
    public Attribute CurrentPsychoLevel => new Attribute(0, "", AttributeNames.CurrentPsychoLevel, AttributeDes.CurrentPsychoLevelDes);
    
    public int MaxHealthValue { get { return MaxHealth.GetValue(); } }
    public int AttackValue { get {return Attack.GetValue();} }
    public int CritChanceValue { get {return CritChance.GetValue();} }
    public int CritDamageValue { get {return CritDamage.GetValue();} }
    public int AttackSpeedValue { get {return AttackSpeed.GetValue();} }
    public int LuckValue { get {return Luck.GetValue();} }
    public int MovementSpeedValue { get {return MovementSpeed.GetValue();} }
    public int MaxPsychoLevelValue { get {return MaxPsychoLevel.GetValue();} }
    public int CurrentPsychoLevelValue { get { return CurrentPsychoLevel.GetValue(); ; } }

    public abstract List<Attribute> GetAttributes();
}