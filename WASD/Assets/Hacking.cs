using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking : RangedWeapon, IUpgradable, IAttackable
{
    protected override string Name => "Hacking";
    protected override float Dmg => 5;
    protected override float CritDmg => 0.5f;
    protected override float CritChance => 0.15f;
    protected override float Lifesteal => 3;
    protected override float AtkSpeed => 0.2f;
    protected override int UpgradeLevel => 1;
    protected override rarity RarityType => rarity.common;    

    protected override bool BulletIsTravelthrough => false;

    protected GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    public void Start()
    {
        bulletPrefab = Resources.Load("Bullets/Bullet") as GameObject;
    }
    public void attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }    

    public void upgradeWeapon(rarity rarityType)
    {
        Debug.Log("Upgrade");
    }
}
