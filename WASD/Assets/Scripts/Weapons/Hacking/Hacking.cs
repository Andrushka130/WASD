using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking : WeaponClass, IRangedWeapon
{
    protected override string Name => "Hacking";
    protected override float Dmg => 5;
    protected override float CritDmg => 0.5f;
    protected override float CritChance => 0.15f;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 0.2f;
    protected override int UpgradeLevel => 1;
    protected override rarity RarityType => rarity.common;
    public bool BulletIsTravelthrough { get; } = false;
    public float timer { get; set; }
    public float cooldown { get; set; } = 1f;   
    public GameObject bulletPrefab { get; } = Resources.Load("Bullets/Bullet") as GameObject;
    public Transform firePoint { get; } = GameObject.Find("Firepoint").transform;
    public float fireForce => 20f;
    
    public void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    public void automaticShooting()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            FireBullet();
            timer = 0;
        }
    }

}
