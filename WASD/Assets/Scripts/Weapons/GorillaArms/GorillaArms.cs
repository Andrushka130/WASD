using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public abstract class GorillaArms : Weapon
{
    public override string Category => WeaponName.GorillaArms;

    public override Sprite Icon => Resources.Load<Sprite>(WeaponIconPath.GorillaArmsIcon);
}
