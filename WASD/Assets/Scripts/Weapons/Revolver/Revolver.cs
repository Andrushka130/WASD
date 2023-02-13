using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public abstract class Revolver : Weapon
{
    public override string Category => WeaponName.Revolver;
    public override Sprite Icon => Resources.Load<Sprite>(WeaponIconPath.RevolverIcon);   
    public abstract GameObject BulletPrefab { get; set;}
    protected abstract Transform FirePoint { get; set;}
    public abstract float FireForce { get; }   
    
}
