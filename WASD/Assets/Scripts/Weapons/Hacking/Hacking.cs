using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking : Weapon, IRangedWeapon
{
    public override string Name => "Hacking";
    public override string Description => "Flood your enemy's brains with disgusting pictures of you only wearing a bib and sitting in a bathtub filled to the brim with chicken nuggets";
    public override int WeaponLevel => 1;
    public override int Value => 5;
    public override float Dmg => 3;
    public override float CritDmg => 1.3f;
    public override int CritChance => 30;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 1f;    
    public override Rarity RarityType => Rarity.Common;
    public bool BulletIsTravelthrough { get; } = false;
    public float Timer { get; set; }  

    public override Sprite Icon => Resources.Load<Sprite>("IconOrdner/Hacking");
    public GameObject BulletPrefab { get; set; }
    public Transform FirePoint { get; set; } 
    public float FireForce => 5f;


    private void Start()
    {
        BulletPrefab = Resources.Load("Bullets/HackingBullets/HackingBullet_1") as GameObject;
        FirePoint = GameObject.Find("firePoint").transform;
    }

    public void FireBullet()
    {
        FirePoint = GameObject.Find("firePoint").transform;
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
