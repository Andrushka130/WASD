using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking_lvl2 : Weapon, IRangedWeapon
{
    public override string Name => "Hacking";
    public override float Dmg => 6;
    protected override float CritDmg => 1.5f;
    protected override int CritChance => 25;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 0.75f;    
    protected override rarity RarityType => rarity.common;
    public override int WeaponLevel => 2;
    public bool BulletIsTravelthrough { get; } = false;
    public float Timer { get; set; }
    public GameObject BulletPrefab { get; set; }
    public Transform FirePoint { get; set; }
    public Transform FirePointLeft { get; set; }    
    public float FireForce => 6f;


    private void Start()
    {
        BulletPrefab = Resources.Load("Bullets/HackingBullets/HackingBullet_2") as GameObject;
        FirePoint = GameObject.Find("firePoint").transform;
        FirePointLeft = GameObject.Find("firePointLeft").transform;
                
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        GameObject bullet2 = Instantiate(BulletPrefab, FirePointLeft.position, FirePointLeft.rotation);
        

        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * FireForce, ForceMode2D.Impulse);
        bullet2.GetComponent<Rigidbody2D>().AddForce(-FirePointLeft.right * FireForce, ForceMode2D.Impulse);       

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
    

