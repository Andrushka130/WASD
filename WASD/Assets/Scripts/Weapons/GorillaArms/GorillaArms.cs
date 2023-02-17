using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public abstract class GorillaArms : Weapon
{
    public override string Category => WeaponName.GorillaArms;
    public override Sprite Icon => Resources.Load<Sprite>(WeaponIconPath.GorillaArmsIcon);
    protected abstract GameObject AttackPrefab { get; set;}    
    protected abstract Transform FirePoint { get; set;}   
    protected abstract float WeaponLifetime { get; }
    public override void InstantiateWeaponPrefab()
    {
        FirePoint = GameObject.Find(WeaponFirePoints.FirePointMelee).transform;
        GameObject gorillaArm = Instantiate(AttackPrefab, FirePoint.position, FirePoint.rotation);
        FindObjectOfType<AudioManager>().Play("GorillaArms");
        Destroy(gorillaArm, WeaponLifetime);
    }
}
