using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public abstract class Hacking : Weapon
{
    public override string Category => WeaponName.Hacking;
    public override Sprite Icon => Resources.Load<Sprite>(WeaponIconPath.HackingIcon);
    protected abstract GameObject BulletPrefab { get; set;}
    protected abstract Transform FirePoint { get; set;}
    protected abstract float FireForce { get; } 
}
