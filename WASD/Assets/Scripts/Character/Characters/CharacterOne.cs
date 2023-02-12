using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttributeResources;
using CharacterResources;

public class CharacterOne : Characters
{
    public override Sprite Icon => Resources.Load<Sprite>("");
    public override Sprite CharSprite => Resources.Load<Sprite>(CharacterSprite.CharOneSprite);
    public override Attribute MaxHealth => new Attribute(20, AttributeIcons.HealthIcon, AttributeNames.Health, AttributeDes.HealthDes);
    public override Attribute Attack => new Attribute(1, AttributeIcons.AttackIcon, AttributeNames.Attack, AttributeDes.AttackDes);
    public override Attribute CritChance => new Attribute(2, AttributeIcons.CritChanceIcon, AttributeNames.CritChance, AttributeDes.CritChanceDes);
    public override Attribute CritDamage => new Attribute(2, AttributeIcons.CritDamageIcon, AttributeNames.CritDamage, AttributeDes.CritDamageDes);
    public override Attribute AttackSpeed => new Attribute(3, AttributeIcons.AttackSpeedIcon, AttributeNames.AttackSpeed, AttributeDes.AttackSpeedDes);
    public override Attribute Luck => new Attribute(4, AttributeIcons.LuckIcon, AttributeNames.Luck, AttributeDes.LuckDes);
    public override Attribute MovementSpeed => new Attribute(13, AttributeIcons.MovementSpeedIcon, AttributeNames.MovementSpeed, AttributeDes.MovementSpeedDes);
    public override Attribute MaxPsychoLevel => new Attribute(20, AttributeIcons.PsychoLevelIcon, AttributeNames.PsychoLevel, AttributeDes.PsychoLevelDes);

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
