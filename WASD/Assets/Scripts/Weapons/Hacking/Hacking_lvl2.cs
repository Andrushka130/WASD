using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking_lvl2 : WeaponClass, IRangedWeapon
{
    protected override string Name => "Hacking_2";
    public override float Dmg => 5;
    protected override float CritDmg => 0.5f;
    protected override float CritChance => 0.15f;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 0.2f;
    protected override int UpgradeLevel => 1;
    protected override rarity RarityType => rarity.common;
    public bool BulletIsTravelthrough { get; } = false;
    public float timer { get; set; }
    public float cooldown { get; set; } = 1f;
    public GameObject bulletPrefab { get; set; }
    public Transform firePoint { get; set; }
    public Transform firePoint2 { get; set; }
    public Transform firePoint3 { get; set; }
    public Transform firePoint4 { get; set; }
    public float fireForce => 20f;


    private void Start()
    {
        bulletPrefab = Resources.Load("Bullets/HackingBullets/HackingBullet_2") as GameObject;
        firePoint = GameObject.Find("firePoint").transform;
        firePoint2 = GameObject.Find("firePoint 2").transform;
        firePoint3 = GameObject.Find("firePoint 3").transform;
        firePoint4 = GameObject.Find("firePoint 4").transform;        
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
        GameObject bullet4 = Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);

        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
        bullet2.GetComponent<Rigidbody2D>().AddForce(-firePoint2.right * fireForce, ForceMode2D.Impulse);
        bullet3.GetComponent<Rigidbody2D>().AddForce(firePoint3.up * fireForce, ForceMode2D.Impulse);
        bullet4.GetComponent<Rigidbody2D>().AddForce(-firePoint4.up * fireForce, ForceMode2D.Impulse);

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
    

