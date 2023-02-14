using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttributeResources;
using CharacterResources;

public class CharacterOne : Characters
{
    private Sprite icon = Resources.Load<Sprite>("");
    private Sprite charSprite = Resources.Load<Sprite>(CharacterSprite.CharOneSprite);
    private Attribute maxHealth = new Attribute(20, AttributeIcons.HealthIcon, AttributeNames.Health, AttributeDes.HealthDes);
    private Attribute attack = new Attribute(1, AttributeIcons.AttackIcon, AttributeNames.Attack, AttributeDes.AttackDes);
    private Attribute critChance = new Attribute(2, AttributeIcons.CritChanceIcon, AttributeNames.CritChance, AttributeDes.CritChanceDes);
    private Attribute critDamage = new Attribute(2, AttributeIcons.CritDamageIcon, AttributeNames.CritDamage, AttributeDes.CritDamageDes);
    private Attribute attackSpeed = new Attribute(3, AttributeIcons.AttackSpeedIcon, AttributeNames.AttackSpeed, AttributeDes.AttackSpeedDes);
    private Attribute luck = new Attribute(4, AttributeIcons.LuckIcon, AttributeNames.Luck, AttributeDes.LuckDes);
    private Attribute movementSpeed = new Attribute(13, AttributeIcons.MovementSpeedIcon, AttributeNames.MovementSpeed, AttributeDes.MovementSpeedDes);
    private Attribute maxPsychoLevel = new Attribute(20, AttributeIcons.PsychoLevelIcon, AttributeNames.PsychoLevel, AttributeDes.PsychoLevelDes);

    public override Sprite Icon => icon;
    public override Sprite CharSprite => charSprite;
    public override Attribute MaxHealth => maxHealth;
    public override Attribute Attack => attack;
    public override Attribute CritChance => critChance;
    public override Attribute CritDamage => critDamage;
    public override Attribute AttackSpeed => attackSpeed;
    public override Attribute Luck => luck;
    public override Attribute MovementSpeed => movementSpeed;
    public override Attribute MaxPsychoLevel => maxPsychoLevel; 
    public override List<Attribute> GetAttributes()
    {
        List<Attribute> attributeList = new List<Attribute>();
        attributeList.Add(MaxHealth);
        attributeList.Add(Attack);
        attributeList.Add(CritChance);
        attributeList.Add(CritDamage);
        attributeList.Add(AttackSpeed);
        attributeList.Add(Luck);
        attributeList.Add(MovementSpeed);
        attributeList.Add(MaxPsychoLevel);

        return attributeList;
    }
}
