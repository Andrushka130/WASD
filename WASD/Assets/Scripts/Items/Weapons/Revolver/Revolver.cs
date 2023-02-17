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

    public override void InstantiateWeaponPrefab()
    {
        FirePoint = GameObject.Find(WeaponFirePoints.FirePoint).transform;
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * FireForce, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play("Revolver");
    }
}
