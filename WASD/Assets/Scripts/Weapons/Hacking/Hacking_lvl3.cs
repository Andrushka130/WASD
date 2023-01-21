using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking_lvl3 : Weapon, IRangedWeapon
{
    public override string Name => "Hacking";
    public override string Description => "Think of something yourself!";
    public override int WeaponLevel => 3;
    public override int Value => 10;
    public override float Dmg => 15;
    public override float CritDmg => 1.75f;
    public override int CritChance => 20;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 0.5f;    
    public override Rarity RarityType => Rarity.Rare;
    public bool BulletIsTravelthrough { get; } = false;
    public float Timer { get; set; }
    public GameObject BulletPrefab { get; set; }
    public Transform FirePoint { get; set; }
    public Transform FirePointLeft { get; set; }
    public Transform FirePointUp { get; set; }
    public Transform FirePointDown { get; set; }
    public float FireForce => 8f;


    private void Start()
    {
        BulletPrefab = Resources.Load("Bullets/HackingBullets/HackingBullet_3") as GameObject;
        FirePoint = GameObject.Find("firePoint").transform;
        FirePointLeft = GameObject.Find("firePointLeft").transform;
        FirePointUp = GameObject.Find("firePointUp").transform;
        FirePointDown = GameObject.Find("firePointDown").transform;
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        GameObject bulletLeft = Instantiate(BulletPrefab, FirePointLeft.position, FirePointLeft.rotation);
        GameObject bulletUp = Instantiate(BulletPrefab, FirePointUp.position, FirePointUp.rotation);
        GameObject bulletDown = Instantiate(BulletPrefab, FirePointDown.position, FirePointDown.rotation);

        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * FireForce, ForceMode2D.Impulse);
        bulletLeft.GetComponent<Rigidbody2D>().AddForce(-FirePointLeft.right * FireForce, ForceMode2D.Impulse);
        bulletUp.GetComponent<Rigidbody2D>().AddForce(FirePointUp.up * FireForce, ForceMode2D.Impulse);
        bulletDown.GetComponent<Rigidbody2D>().AddForce(-FirePoint.up * FireForce, ForceMode2D.Impulse);
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
