using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;


public class Revolver_lvl1 : Weapon, IRangedWeapon
{
    public override string Name => "Revolver";
    public override float Dmg => 5;
    protected override float CritDmg => 1.5f;
    protected override int CritChance => 20;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 1.3f;    
    protected override Rarity RarityType => Rarity.Uncommon;
    public override int WeaponLevel => 1;
    public bool BulletIsTravelthrough { get; } = false;
    public float Timer { get; set; }
    public GameObject BulletPrefab { get; set; }
    public Transform FirePoint { get; set; }
    public float FireForce => 30f;

    private void Start()
    {
        BulletPrefab = Resources.Load("Bullets/RevolverBullets/RevolverBullet") as GameObject;
        FirePoint = GameObject.Find("firePoint").transform;
    }

    public void FireBullet()
    {  
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);     
        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * FireForce, ForceMode2D.Impulse);
    }

    public override void Attack()
    {
        Timer += Time.deltaTime;
        if (Timer > GetCooldown())
        {
            FireBullet();            
            Timer = 0;
        }
    }
    
    public override void DestroyScript(){
        Destroy(this);
    }

}

