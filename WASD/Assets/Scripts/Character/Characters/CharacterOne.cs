using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttributeResources;
using CharacterResources;

public class CharacterOne : Characters
{
    public override Sprite Icon => Resources.Load<Sprite>("");
    public override Sprite CharSprite => Resources.Load<Sprite>(CharacterSprite.CharOneSprite);
    public override Attribute MaxHealth => new Attribute(20, AttributeIcons.HealthIcon);
    public override Attribute Attack => new Attribute(1, AttributeIcons.AttackIcon);
    public override Attribute CritChance => new Attribute(2, AttributeIcons.CritChanceIcon);
    public override Attribute CritDamage => new Attribute(2, AttributeIcons.CritDamageIcon);
    public override Attribute AttackSpeed => new Attribute(3, AttributeIcons.AttackSpeedIcon);
    public override Attribute Luck => new Attribute(4, AttributeIcons.LuckIcon);
    public override Attribute MovementSpeed => new Attribute(13, AttributeIcons.MovementSpeedIcon);
    public override Attribute MaxPsychoLevel => new Attribute(20, AttributeIcons.PsychoLevelIcon);

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
