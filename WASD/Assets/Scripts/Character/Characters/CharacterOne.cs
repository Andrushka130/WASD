using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOne : Characters
{
    public override Sprite Icon => Resources.Load<Sprite>("");
    public override Sprite CharSprite => Resources.Load<Sprite>("");
    public override Attribute MaxHealth => new Attribute(20, "");
    public override Attribute Attack => new Attribute(1, "");
    public override Attribute CritChance => new Attribute(2, "");
    public override Attribute CritDamage => new Attribute(2, "");
    public override Attribute AttackSpeed => new Attribute(3, "");
    public override Attribute Luck => new Attribute(4, "");
    public override Attribute MovementSpeed => new Attribute(13, "");
    public override Attribute MaxPsychoLevel => new Attribute(20, "");

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
