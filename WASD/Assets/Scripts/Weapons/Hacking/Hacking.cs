using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking : Weapon, IRangedWeapon
{
    public override string Name => "Hacking";
    public override float Dmg => 5;
    protected override float CritDmg => 0.5f;
    protected override float CritChance => 0.15f;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 0.2f;    
    protected override rarity RarityType => rarity.common;
    public override int WeaponLevel => 1;
    public bool BulletIsTravelthrough { get; } = false;
    public float timer { get; set; }
    public float cooldown { get; set; } = 1f;   
    public GameObject bulletPrefab { get; set; }
    public Transform firePoint { get; set; } 
    public float fireForce => 5f;


    private void Start()
    {
        bulletPrefab = Resources.Load("Bullets/HackingBullets/HackingBullet_1") as GameObject;
        firePoint = GameObject.Find("firePoint").transform;
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
    }

    public override void attack()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            FireBullet();
            timer = 0;
        }
    }

    public override void DestroyScript(){
        Destroy(this);
    }

}
