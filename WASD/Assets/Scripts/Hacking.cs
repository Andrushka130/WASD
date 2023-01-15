using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking : RangedWeapon
{
    protected override string Name => "Hacking";
    protected override float Dmg => 5;
    protected override float CritDmg => 0.5f;
    protected override float CritChance => 0.15f;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 0.2f;
    protected override int UpgradeLevel => 1;
    protected override Rarity RarityType => Rarity.Common;    

    protected override bool BulletIsTravelthrough => false;

    private GameObject bulletPrefab;
    private Transform firePoint;
    private float fireForce = 20f;

    public void Start()
    {
        bulletPrefab = Resources.Load("Bullets/Bullet") as GameObject;
        firePoint = GameObject.Find("Firepoint").transform;
    }
    public override void attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }    

    public override void upgradeWeapon(Rarity rarityType)
    {
        Debug.Log("Upgrade");
    }
}
