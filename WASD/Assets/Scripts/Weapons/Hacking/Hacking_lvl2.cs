using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking_lvl2 : WeaponClass, IRangedWeapon
{
    protected override string Name => "Hacking_2";
    public override float Dmg => 10;
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
    public Transform firePointLeft { get; set; }    
    public float fireForce => 20f;


    private void Start()
    {
        bulletPrefab = Resources.Load("Bullets/HackingBullets/HackingBullet_2") as GameObject;
        firePoint = GameObject.Find("firePoint").transform;
        firePointLeft = GameObject.Find("firePointLeft").transform;
                
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
        

        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
        bullet2.GetComponent<Rigidbody2D>().AddForce(-firePointLeft.right * fireForce, ForceMode2D.Impulse);       

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
    

