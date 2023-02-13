using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public abstract class Katana : Weapon
{
    public override string Category => WeaponName.Katana;
    public override Sprite Icon => Resources.Load<Sprite>(WeaponIconPath.KatanaIcon);
    protected abstract GameObject AttackPrefab { get; set;}    
    protected abstract Transform FirePoint { get; set;}   
    protected abstract float WeaponLifetime { get; }
}
