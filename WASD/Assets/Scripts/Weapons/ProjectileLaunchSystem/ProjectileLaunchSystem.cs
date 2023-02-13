using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public abstract class ProjectileLaunchSystem : Weapon
{
    public override string Category => WeaponName.ProjectileLauncherSystem;

    public override Sprite Icon => Resources.Load<Sprite>(WeaponIconPath.ProjectileLauncherSystemIcon);
}
